//-----------------------------------------------------------------------
// <copyright file="RelatedType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates relationship types for VTriggers.
    /// </summary>
    public enum RelatedType
    {
        /// <summary>
        /// Alarm will trigger relative to the start of the event.
        /// </summary>
        START,

        /// <summary>
        /// Alarm will trigger relative to the end of the event.
        /// </summary>
        END
    }
}
