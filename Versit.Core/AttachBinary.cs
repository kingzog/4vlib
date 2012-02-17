//-----------------------------------------------------------------------
// <copyright file="VAttachBinary.cs" company="4verse">
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
    /// A binary attachment.
    /// </summary>
    public class AttachBinary : Image, IProperty, IAttachment
    {
        /// <summary>
        /// Initializes a new instance of the AttachBinary class.
        /// </summary>
        public AttachBinary()
            : base("ATTACH")
        {
        }
    }
}
