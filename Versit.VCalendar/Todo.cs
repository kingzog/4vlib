//-----------------------------------------------------------------------
// <copyright file="Todo.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Versit.Core;

    /// <summary>
    /// A todo item.
    /// </summary>
    public class Todo : CalendarBase
    {
        /// <summary>
        /// Initializes a new instance of the Todo class.
        /// </summary>
        public Todo()
            : base(VersitObjectType.VTODO)
        {
            this.Fields.Add(new Property<DateTime>("DUE", DateTime.MinValue));
            this.Fields.Add(new Property<DateTime?>("COMPLETE", null));

            this.Fields.Add(new Property<decimal>("PERCENT-COMPLETE", 0));
            this.Fields.Add(new Property<int>("PRIORITY", 0));
            this.Fields.Add(new Property<CalendarStatus>("STATUS", CalendarStatus.SENT));
        }

        /// <summary>
        /// Gets or sets the date/time this todo item is
        /// due to be completed.
        /// </summary>
        public DateTime Due
        {
            get { return GetPropertyValue<DateTime>("DUE"); }
            set { SetPropertyValue<DateTime>("DUE", value); }
        }

        /// <summary>
        /// Gets or sets the date/time this todo item was
        /// marked as completed.
        /// </summary>
        public DateTime? Complete
        {
            get { return GetPropertyValue<DateTime?>("COMPLETE"); }
            set { SetPropertyValue<DateTime?>("COMPLETE", value); }
        }

        /// <summary>
        /// Gets or sets a decimal representing the percentage
        /// completion of this event (0-1).
        /// </summary>
        /// <remarks>
        /// Has no effect on the completion status of this todo
        /// item (that is based on <c>Complete</c>).
        /// </remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">Percentages must be a decimal between 0 and 1</exception>
        public decimal PercentComplete
        {
            get
            {
                return GetPropertyValue<decimal>("PERCENT-COMPLETE");
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", Versit.Core.Properties.Resources.Exception_PercentageOutOfRange);
                }

                SetPropertyValue<decimal>("PERCENT-COMPLETE", value);
            }
        }

        /// <summary>
        /// Gets or sets a number representing the priority of this
        /// todo item (with 1 being the highest).
        /// </summary>
        public int Priority
        {
            get { return GetPropertyValue<int>("PRIORITY"); }
            set { SetPropertyValue<int>("PRIORITY", value); }
        }

        /// <summary>
        /// Gets or sets the status of this todo item.
        /// </summary>
        public CalendarStatus Status
        {
            get { return GetPropertyValue<CalendarStatus>("STATUS"); }
            set { SetPropertyValue<CalendarStatus>("STATUS", value); }
        }
    }
}