//-----------------------------------------------------------------------
// <copyright file="ExpectType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates the types of response or attendance required from the attendee.
    /// </summary>
    public enum ExpectType
    {
        /// <summary>
        /// Indicates an unknown or blank value
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Indicates request is for your information; default
        /// </summary>
        FYI,

        /// <summary>
        /// Indicates presence is definitely required
        /// </summary>
        REQUIRE,

        /// <summary>
        /// Indicates presence is being requested
        /// </summary>
        REQUEST,

        /// <summary>
        /// Indicates an immediate response needed
        /// </summary>
        IMMEDIATE
    }
}
