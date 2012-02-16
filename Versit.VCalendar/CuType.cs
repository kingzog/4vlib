//-----------------------------------------------------------------------
// <copyright file="CuType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates the types of calendar user specified by a <c>VCalendarBase</c>.
    /// </summary>
    public enum CuType
    {
        /// <summary>
        /// Otherwise not known
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// An individual
        /// </summary>
        INDIVIDUAL,

        /// <summary>
        /// A group of individuals
        /// </summary>
        GROUP,

        /// <summary>
        /// A physical resource
        /// </summary>
        RESOURCE,

        /// <summary>
        /// A room resource
        /// </summary>
        ROOM
    }
}
