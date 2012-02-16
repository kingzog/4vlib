using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Versit.Core
{
    /// <summary>
    /// Exports a <c>VObject</c> to XML.
    /// </summary>
    public class XmlExporter
    {
        /// <summary>
        /// Document to be returned.
        /// </summary>
        private XmlDocument document;

        /// <summary>
        /// Initializes a new instance of the XmlExporter class.
        /// </summary>
        /// <param name="data">Data to export</param>
        public XmlExporter(IVObject data)
        {
            this.Data = data;
            this.document = new XmlDocument();
        }

        /// <summary>
        /// Gets the object being exported.
        /// </summary>
        public IVObject Data { get; private set; }

        /// <summary>
        /// Exports <c>Data</c> to XML.
        /// </summary>
        /// <returns>An <c>XmlDocument</c> describing the object
        /// stored in <c>Data</c>.</returns>
        public IXPathNavigable Export()
        {
            var docType = this.document.CreateXmlDeclaration("1.0", null, null);
            this.document.AppendChild(docType);

            /* create a root element, having the same name 
             * as our Data object's type (e.g. vcontact, 
             * vevent, etc) cast to lowercase for XML style
             * compliance.
             * */

            var root = this.document.CreateElement(this.Data.Type.ToString().ToLower(CultureInfo.CurrentCulture));
            root.SetAttribute("version", this.Data.Version);
            this.document.AppendChild(root);

            /* export all core fields into our document as
             * top-level elements.
             * */

            this.ExportFieldCollection(this.Data.Fields, root);

            /* export any additional field collections into
             * our document as children of their own 
             * child nodes.
             * */

            if (this.Data.FieldCollections.Count > 1)
            {
                foreach (var fields in this.Data.FieldCollections.Where(f => f.Key != VBase.BaseFieldCollectionKey))
                {
                    var subElement = this.document.CreateElement(fields.Key.ToLower(CultureInfo.CurrentCulture));
                    root.AppendChild(subElement);

                    this.ExportFieldCollection(fields.Value, subElement);
                }
            }

            return this.document;
        }

        /// <summary>
        /// Exports a <c>IVProperty</c> to the XmlDocument.
        /// </summary>
        /// <param name="field">Field to export</param>
        /// <param name="rootElement">Element to append the data to</param>
        private void ExportField(IVProperty field, XmlElement rootElement)
        {
            if (field.IsEmpty())
            {
                return;
            }

            var fieldNode = this.document.CreateElement(field.Name.ToLower(CultureInfo.CurrentCulture));
            fieldNode.InnerText = field.ValueToString();

            foreach (var parameter in field.Parameters)
            {
                fieldNode.SetAttribute(parameter.Key, parameter.Value);
            }

            rootElement.AppendChild(fieldNode);
        }

        /// <summary>
        /// Exports a collection of VProperties to the XmlDocument.
        /// </summary>
        /// <param name="fields">Field collection to export</param>
        /// <param name="rootElement">Root element to export to</param>
        private void ExportFieldCollection(VPropertyCollection fields, XmlElement rootElement)
        {
            foreach (var field in fields)
            {
                this.ExportField(field, rootElement);
            }
        }
    }
}
