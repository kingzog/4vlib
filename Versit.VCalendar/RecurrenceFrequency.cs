//-----------------------------------------------------------------------
// <copyright file="RecurrenceFrequency.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    /// <summary>
    /// Enumerates frequencies of recurrence.
    /// </summary>
    public enum RecurrenceFrequency
    {
        /// <summary>
        /// Recurs every second.
        /// </summary>
        SECONDLY,

        /// <summary>
        /// Recurs every minute.
        /// </summary>
        MINUTELY,

        /// <summary>
        /// Recurs every hour.
        /// </summary>
        HOURLY,

        /// <summary>
        /// Recurs every day.
        /// </summary>
        DAILY,

        /// <summary>
        /// Recurs every week.
        /// </summary>
        WEEKLY,

        /// <summary>
        /// Recurs every month.
        /// </summary>
        MONTHLY,

        /// <summary>
        /// Recurs every year.
        /// </summary>
        YEARLY
    }
}
