//-----------------------------------------------------------------------
// <copyright file="VStatus.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Status associated with a vCalendar entity.
    /// </summary>
    /// <remarks>
    /// This property can be used when the ATTENDEE property 
    /// is either not supported or not needed
    /// </remarks>
    public enum CalendarStatus
    {
        /// <summary>
        /// Indicates an unknown or blank value
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Indicates todo was accepted
        /// </summary>
        ACCEPTED,

        /// <summary>
        /// Indicates event or todo requires action
        /// </summary>
        NEEDS_ACTION,

        /// <summary>
        /// Indicates event or todo was sent out
        /// </summary>
        SENT,

        /// <summary>
        /// Indicates event is tentatively accepted
        /// </summary>
        TENTATIVE,

        /// <summary>
        /// Indicates event is confirmed
        /// </summary>
        CONFIRMED,

        /// <summary>
        /// Indicates event or todo has been declined
        /// </summary>
        DECLINED,

        /// <summary>
        /// Indicates todo has been completed
        /// </summary>
        COMPLETED,

        /// <summary>
        /// Indicates event or todo has been delegated
        /// </summary>
        DELEGATED
    }
}
