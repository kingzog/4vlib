//-----------------------------------------------------------------------
// <copyright file="RoleType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates the possible roles an attendee may have on an event or task.
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// Indicates an unknown or blank value
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Indicates an attendee at the event or  todo
        /// </summary>
        ATTENDEE,

        /// <summary>
        /// Indicates organizer  of the event, but not owner
        /// </summary>
        ORGANIZER,

        /// <summary>
        /// Indicates owner of the event or todo
        /// </summary>
        OWNER,

        /// <summary>
        /// Indicates a delegate of another attendee
        /// </summary>
        DELEGATE
    }
}
