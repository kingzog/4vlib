//-----------------------------------------------------------------------
// <copyright file="VAlarmBase.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core.Properties;
    using System.Collections.Generic;
    using Versit.Core;

    /// <summary>
    /// Provides a grouping of component properties that define an 
    /// alarm to be associated with a derivative of VCalendarBase.
    /// </summary>
    public abstract class AlarmBase : VersitBase, IAlarm
    {
        /// <summary>
        /// Initializes a new instance of the VAlarm class.
        /// </summary>
        /// <param name="action">Alarm action that should be triggered</param>
        /// <param name="trigger">Trigger for this alarm</param>
        protected AlarmBase(AlarmAction action, ITrigger trigger)
            : base(VersitObjectType.VALARM)
        {
            this.Fields.Add(new Property<AlarmAction>("ACTION", action));
            this.Fields.Add(new Duration("DURATION"));
            this.Fields.Add(trigger);
        }

        /// <summary>
        /// Gets the action to take when this alarm is triggered.
        /// </summary>
        public AlarmAction Action
        {
            get { return GetPropertyValue<AlarmAction>("ACTION"); }
            protected set { SetPropertyValue<AlarmAction>("ACTION", value); }
        }

        /// <summary>
        /// Gets or sets a value specifying when this alarm will
        /// be triggered.
        /// </summary>
        public ITrigger Trigger
        {
            get { return GetProperty<ITrigger>("TRIGGER"); }
            set { SetProperty("TRIGGER", value); }
        }

        /// <summary>
        /// Gets or sets the delay period prior to repeating the alarm.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return GetPropertyValue<TimeSpan>("DURATION");
            }
            set
            {
                if (!this.Repeat.HasValue)
                {
                    this.Repeat = 1; // must have a repeat if there is a duration
                }

                SetPropertyValue<TimeSpan>("DURATION", value);
            }
        }

        /// <summary>
        /// Gets or sets a value specifying the number of additional 
        /// repetitions that the alarm will trigger, in addition to 
        /// the initial triggering of the alarm.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Alarm repeat cannot be less than 0</exception>
        public int? Repeat
        {
            get
            {
                return GetPropertyValue<int?>("REPEAT");
            }
            set
            {
                if (value.HasValue && value.Value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", Resources.Exception_AlarmRepeatOutOfRange);
                }

                SetPropertyValue<int?>("REPEAT", value);
            }
        }

        /// <summary>
        /// Gets an array of times when this alarm will trigger.
        /// </summary>
        /// <param name="parent">Parent calendar item (to get the start date if this alarm's trigger is relative
        /// to its parent event)</param>
        /// <returns>An array of DateTime values</returns>
        public DateTime[] GetAlarmTimes(CalendarBase parent)
        {
            var dates = new List<DateTime>();
            DateTime firstDate; // this is when the alarm is first triggered

            firstDate = DateTime.Now; // TODO

            // add the first date (every alarm will have at least one)
            dates.Add(firstDate);

            // add any repeat dates
            if (this.Repeat.HasValue && this.Duration != null)
            {
                for (int i = 0; i < this.Repeat.Value; i++)
                {
                    dates.Add(firstDate.Add(this.Duration));
                }
            }

            return dates.ToArray();
        }
    }
}
