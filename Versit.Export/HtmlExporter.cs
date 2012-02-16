using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Versit.Core;

namespace Versit.Export
{
    public class HtmlExporter : IExporter
    {
        public StringDictionary TagMap { get; private set; }

        public string DefaultHtmlTag { get; set; }

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
            string tagName;

            if (this.TagMap.ContainsKey(property.Name))
            {
                tagName = this.TagMap[property.Name];
            }
            else
            {
                tagName = this.DefaultHtmlTag;
            }

            throw new NotImplementedException();
        }

        public System.IO.Stream ToStream()
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream ToStream(Encoding encoding)
        {
            throw new NotImplementedException();
        }
    }
}
