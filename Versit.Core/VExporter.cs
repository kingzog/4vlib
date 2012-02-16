using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Versit.Core
{
    /// <summary>
    /// Exports a <c>VObject</c> to string.
    /// </summary>
    public class Exporter
    {
        /// <summary>
        /// Defines the standard array delimiter character string.
        /// </summary>
        public const string ArrayDelimiter = ";";

        /// <summary>
        /// Defines the standard format (ISO 8601) for DateTime
        /// values when written to string.
        /// </summary>
        public const string DateTimeFormat = "o";

        /// <summary>
        /// Initializes a new instance of the Exporter class.
        /// </summary>
        /// <param name="data">Data to export</param>
        public Exporter(IVObject data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets the object being exported.
        /// </summary>
        public IVObject Data { get; private set; }

        /// <summary>
        /// Writes an <c>IVProperty</c> to string.
        /// </summary>
        /// <param name="property">Property to write</param>
        /// <returns>A string representation of an <c>IVProperty</c></returns>
        public static string WriteProperty(IVProperty property)
        {
            var sb = new StringBuilder();

            sb.Append((property.Name ?? string.Empty).ToUpper(CultureInfo.CurrentCulture)); // molly-guard

            if (property.Parameters != null &&
                property.Parameters.Any())
            {
                foreach (var param in property.Parameters)
                {
                    if (string.IsNullOrEmpty(param.Value) ||
                        param.Value == "UNKNOWN")
                    {
                        /* ignore blank parameters, or enum parameters
                         * which have been set to (or left as) unknown;
                         * these are effectively NULL values.
                         * */

                        continue;
                    }

                    sb.Append(";");

                    if (!string.IsNullOrEmpty(param.Key) &&
                        param.Key != param.Value)
                    {
                        /* If the key is non-empty and not the same as the value,
                         * we can use a typical KEY=VALUE format (most params will
                         * use this format). It is supported in the Versit 
                         * specification to have VALUE;VALUE;VALUE params, e.g.
                         * TEL;WORK;FAX:01904691066, so we support that by using
                         * either blank keys or keys which match the value.
                         * */

                        sb.AppendFormat("{0}=", param.Key);
                    }

                    sb.Append(param.Value);
                }
            }

            sb.AppendFormat(":{0}", property.ValueToString());
            return sb.ToString();
        }

        /// <summary>
        /// Exports the <c>Data</c> to string.
        /// </summary>
        /// <returns>A string representation of the <c>IVObject</c> in <c>Data</c></returns>
        public virtual string Export()
        {
            var sb = new StringBuilder();
            sb.AppendLine("BEGIN:" + this.Data.Type.ToString());
            sb.AppendLine("VERSION:" + this.Data.Version);

            foreach (var collection in this.Data.FieldCollections)
            {
                foreach (var property in collection.Value)
                {
                    if (!property.IsEmpty())
                    {
                        sb.AppendLine(WriteProperty(property));
                    }
                }
            }

            foreach (var item in this.Data.InnerElements)
            {
                var exporter = new Exporter(item);
                sb.Append(exporter.Export());
            }

            sb.AppendLine("END:" + this.Data.Type.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Saves this <c>IVObject</c> as a file on disk.
        /// </summary>
        /// <param name="path">Full path to the destination file, including extension</param>
        public void SaveAs(string path)
        {
            if (File.Exists(path))
            {
                throw new IOException("File already exists!");
            }

            StreamWriter sw = new StreamWriter(path);

            var data = this.Export();
            sw.Write(data);

            sw.Close();
        }
    }
}
