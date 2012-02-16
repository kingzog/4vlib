//-----------------------------------------------------------------------
// <copyright file="ClassificationType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    /// <summary>
    /// Enumerates different types of access classification for objects.
    /// </summary>
    public enum ClassificationType
    {
        /// <summary>
        /// Indicates general, public access
        /// </summary>
        PUBLIC,

        /// <summary>
        /// Indicates restricted, private access
        /// </summary>
        PRIVATE,

        /// <summary>
        /// Indicates very restricted, confidential access
        /// </summary>
        CONFIDENTIAL
    }
}
