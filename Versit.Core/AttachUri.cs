//-----------------------------------------------------------------------
// <copyright file="VAttachUri.cs" company="4verse">
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
    /// A Uri attachment.
    /// </summary>
    public class AttachUri : Property<Uri>, IProperty, IAttachment
    {
        /// <summary>
        /// Initializes a new instance of the VAttachUri class.
        /// </summary>
        public AttachUri()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VAttachUri class.
        /// </summary>
        /// <param name="uri">Attachment Uri</param>
        public AttachUri(Uri uri)
            : base("ATTACH", uri)
        {
        }
    }
}
