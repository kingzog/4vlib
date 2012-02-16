using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Versit.Core;

namespace Versit.Export
{
    public class ConsoleExporter : IExporter
    {
        public void WriteBeginTag(IVersitObject obj)
        {
            Console.WriteLine(obj.Type.ToString());
        }

        public void WriteEndTag(IVersitObject obj)
        {
            Console.WriteLine();
        }

        public void WriteProperty(IProperty property)
        {
            Console.WriteLine(property.ToString());
        }

        #region Not supported

        public System.IO.Stream ToStream()
        {
            throw new NotSupportedException("Console exporter cannot write to a stream");
        }

        public System.IO.Stream ToStream(Encoding encoding)
        {
            throw new NotSupportedException("Console exporter cannot write to a stream");
        }

        #endregion
    }
}
