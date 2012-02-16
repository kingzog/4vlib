//-----------------------------------------------------------------------
// <copyright file="VEvent.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core;

    /// <summary>
    /// A calendar event.
    /// </summary>
    public class Event : CalendarBase
    {
        /// <summary>
        /// Initializes a new instance of the VEvent class.
        /// </summary>
        public Event()
            : base(VersitObjectType.VEVENT)
        {
            this.Fields.Add(new Property<int>("PRIORITY", 0));
        }

        /// <summary>
        /// Gets or sets a number representing the priority of this
        /// calendar item (with 1 being the highest).
        /// </summary>
        public int Priority
        {
            get { return GetPropertyValue<int>("PRIORITY"); }
            set { SetPropertyValue<int>("PRIORITY", value); }
        }
    }
}
