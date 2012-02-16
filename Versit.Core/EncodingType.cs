//-----------------------------------------------------------------------
// <copyright file="EncodingType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    /// <summary>
    /// Enumerates types of encoding which may be used for the 
    /// values of VProperties.
    /// </summary>
    public enum EncodingType
    {
        /// <summary>
        /// Normal text
        /// </summary>
        QUOTEDPRINTABLE,

        /// <summary>
        /// Base 64 format
        /// </summary>
        BASE64,

        /// <summary>
        /// 8-bit format
        /// </summary>
        EIGHTBIT
    }
}
