//-----------------------------------------------------------------------
// <copyright file="RecurrenceRule.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Base class for recurrence rules.
    /// </summary>
    /// <remarks>
    /// See http://www.kanzaki.com/docs/ical/recur.html
    /// </remarks>
    public class RecurrenceRule
    {
        /// <summary>
        /// Initializes a new instance of the RecurrenceRule class.
        /// </summary>
        public RecurrenceRule()
        {
        }

        /// <summary>
        /// Gets or sets the recurrence frequency.
        /// </summary>
        public RecurrenceFrequency Frequency { get; set; }

        /// <summary>
        /// Gets or sets the interval number.
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        /// Gets or sets the second numbers to recur on.
        /// </summary>
        public int[] BySeconds { get; set; }

        /// <summary>
        /// Gets or sets the hour numbers to recur on.
        /// </summary>
        public int[] ByHours { get; set; }

        /// <summary>
        /// Gets or sets the days of the week to recur on.
        /// </summary>
        public DayOfWeek[] ByDays { get; set; }

        /// <summary>
        /// Gets or sets the days of the month to recur on.
        /// </summary>
        public int[] ByMonthDays { get; set; }

        /// <summary>
        /// Gets or sets the days of the year to recur on.
        /// </summary>
        public int[] ByYearDays { get; set; }

        /// <summary>
        /// Gets or sets the weeks of the year to recur on.
        /// </summary>
        public int[] ByWeekNumbers { get; set; }

        /// <summary>
        /// Gets or sets the months of the year to recur on.
        /// </summary>
        public int[] ByMonths { get; set; }

        /// <summary>
        /// Gets or sets the set position of something or other.
        /// </summary>
        public int[] BySetPos { get; set; }

        /// <summary>
        /// Gets or sets the week start(?)
        /// </summary>
        public int WeekStart { get; set; }
    }
}
