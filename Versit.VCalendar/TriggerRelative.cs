//-----------------------------------------------------------------------
// <copyright file="TriggerRelative.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;

    /// <summary>
    /// A trigger relative to an event.
    /// </summary>
    public class TriggerRelative : Duration, ITrigger
    {
        /// <summary>
        /// Initializes a new instance of the TriggerRelative class.
        /// </summary>
        /// <remarks>
        /// Sets a default duration of 15 minutes before the start.
        /// </remarks>
        public TriggerRelative()
            : this(new TimeSpan(0, -15, 0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the TriggerRelative class.
        /// </summary>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public TriggerRelative(int hours, int minutes, int seconds)
            : this(new TimeSpan(hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Initializes a new instance of the TriggerRelative class.
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public TriggerRelative(int days, int hours, int minutes, int seconds)
            : this(new TimeSpan(days, hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Initializes a new instance of the TriggerRelative class.
        /// </summary>
        /// <param name="value">Duration of this trigger</param>
        /// <remarks>Initializes a relative trigger</remarks>
        public TriggerRelative(TimeSpan value)
            : base("TRIGGER", value)
        {
            this.Parameters.Add("VALUE", "DURATION");
            this.Parameters.Add("RELATED", RelatedType.START.ToString());
        }

        /// <summary>
        /// Gets or sets which point of the event this trigger's duration
        /// relates to (start or end).
        /// </summary>
        public RelatedType Related
        {
            get { return GetEnumParameter<RelatedType>("RELATED"); }
            set { SetParameter("RELATED", value); }
        }
    }
}
