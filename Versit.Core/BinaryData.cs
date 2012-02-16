//-----------------------------------------------------------------------
// <copyright file="VBinary.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A binary property.
    /// </summary>
    public class BinaryData : Property<string>, IProperty
    {
        /// <summary>
        /// Initializes a new instance of the VBinary class.
        /// </summary>
        /// <param name="name">Property name</param>
        public BinaryData(string name)
            : base(name, string.Empty)
        {
            this.Parameters.Add("ENCODING", BinaryEncoding.BASE64.ToString());
            this.Parameters.Add("VALUE", "BINARY");
        }

        /// <summary>
        /// Gets the encoding of this binary object.
        /// </summary>
        public new BinaryEncoding Encoding
        {
            get { return GetEnumParameter<BinaryEncoding>("ENCODING"); }
        }
    }
}
