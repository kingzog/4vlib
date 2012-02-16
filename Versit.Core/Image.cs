//-----------------------------------------------------------------------
// <copyright file="VImage.cs" company="4verse">
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
    /// Embedded representation of an image.
    /// </summary>
    public class Image : Property<string>
    {
        /// <summary>
        /// Initializes a new instance of the VImage class.
        /// </summary>
        /// <param name="name">Property name</param>
        public Image(string name)
            : base(name, string.Empty)
        {
            this.Parameters.Add("ENCODING", BinaryEncoding.BASE64.ToString());
            this.Parameters.Add("TYPE", ImageType.JPEG.ToString());
            this.Parameters.Add("VALUE", "INLINE");
        }

        /// <summary>
        /// Initializes a new instance of the VImage class.
        /// </summary>
        /// <param name="name">Name of this property</param>
        /// <param name="data">Data to encode</param>
        /// <param name="type">Encoding type to use</param>
        public Image(string name, byte[] data, ImageType type)
            : base(name, Convert.ToBase64String(data))
        {
            this.ImageType = type;
        }

        /// <summary>
        /// Gets the encoding of this image.
        /// </summary>
        public new BinaryEncoding Encoding
        {
            get { return GetEnumParameter<BinaryEncoding>("ENCODING"); }
        }

        /// <summary>
        /// Gets or sets the type of image format.
        /// </summary>
        public ImageType ImageType
        {
            get { return GetEnumParameter<ImageType>("TYPE"); }
            set { SetParameter("TYPE", value); }
        }

        /// <summary>
        /// Gets or sets the type of image referenced, inline or linked.
        /// </summary>
        public string ImageValue
        {
            get { return GetParameter("VALUE"); }
            set { SetParameter("VALUE", value); }
        }
    }
}
