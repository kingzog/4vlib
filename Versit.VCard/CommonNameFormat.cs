//-----------------------------------------------------------------------
// <copyright file="CommonNameFormat.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    /// <summary>
    /// Common name formats.
    /// </summary>
    public enum CommonNameFormat
    {
        /// <summary>
        /// First name first
        /// </summary>
        /// <example>Keith Williams</example>
        FirstLast,

        /// <summary>
        /// Last name first
        /// </summary>
        /// <example>Williams, Keith</example>
        LastFirst
    }
}
