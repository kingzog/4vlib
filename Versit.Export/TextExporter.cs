using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Versit.Core;
using System.IO;

namespace Versit.Export
{
    public class TextExporter : IExporter
    {
        private StringBuilder sb = new StringBuilder();

        public void WriteBeginTag(IVersitObject obj)
        {
            throw new NotImplementedException();
        }

        public void WriteEndTag(IVersitObject obj)
        {
            throw new NotImplementedException();
        }

        public void WriteProperty(IProperty property)
        {
            sb.Append(property.ToString());
        }

        public Stream ToStream()
        {
            return this.ToStream(Encoding.UTF8);
        }

        public Stream ToStream(Encoding encoding)
        {
            var bytes = encoding.GetBytes(this.sb.ToString());
            return new MemoryStream(bytes);
        }
    }
}
