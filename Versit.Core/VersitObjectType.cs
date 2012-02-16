//-----------------------------------------------------------------------
// <copyright file="ObjectType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    /// <summary>
    /// Enumerates types of Versit objects.
    /// </summary>
    public enum VersitObjectType
    {
        /// <summary>
        /// Unknown type
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// Calendar of events
        /// </summary>
        VCALENDAR = 1,

        /// <summary>
        /// Calendar event
        /// </summary>
        VEVENT = 2,

        /// <summary>
        /// A todo or task item
        /// </summary>
        VTODO = 3,

        /// <summary>
        /// Contact details
        /// </summary>
        VCARD = 4,

        /// <summary>
        /// An alarm or alert
        /// </summary>
        VALARM = 5,

        /// <summary>
        /// A journal entry
        /// </summary>
        VJOURNAL = 6
    }
}
