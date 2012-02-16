//-----------------------------------------------------------------------
// <copyright file="AlarmAction.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates the action to be invoked when a VAlarm is triggered
    /// </summary>
    public enum AlarmAction
    {
        /// <summary>
        /// Sound an audible alarm.
        /// </summary>
        AUDIO,
        
        /// <summary>
        /// Display a message.
        /// </summary>
        DISPLAY,
        
        /// <summary>
        /// Send an email to the attendee(s).
        /// </summary>
        EMAIL,
        
        /// <summary>
        /// Run a procedure.
        /// </summary>
        PROCEDURE
    }
}
