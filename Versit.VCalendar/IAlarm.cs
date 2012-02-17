//-----------------------------------------------------------------------
// <copyright file="IAlarm.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core;

    /// <summary>
    /// An alarm which can be nested in a VCalendarBase object.
    /// </summary>
    public interface IAlarm : IVersitObject
    {
        /// <summary>
        /// Gets the action to take when this alarm is triggered.
        /// </summary>
        AlarmAction Action { get; }

        /// <summary>
        /// Gets or sets the delay period prior to repeating the alarm.
        /// </summary>
        TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets a value specifying the number of additional 
        /// repetitions that the alarm will trigger, in addition to 
        /// the initial triggering of the alarm.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Alarm repeat cannot be less than 0</exception>
        int? Repeat { get; set; }

        /// <summary>
        /// Gets or sets a value specifying when this alarm will
        /// be triggered.
        /// </summary>
        ITrigger Trigger { get; set; }
    }
}
