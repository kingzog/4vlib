//-----------------------------------------------------------------------
// <copyright file="VCalendarBase.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using Versit.Core;

    /// <summary>
    /// Base class for vEvent and vTodo items.
    /// </summary>
    /// <remarks>
    /// Provides standard functionality for calendar-based classes.
    /// </remarks>
    /// <see cref="Versit.VCalendar.Event"/>
    /// <see cref="Versit.VCalendar.Todo"/>
    public abstract class CalendarBase : VersitBase, ICalendarItem
    {
        /// <summary>
        /// Initializes a new instance of the VCalendarBase class.
        /// </summary>
        /// <param name="type">Calendar object type (must be either VEVENT or VTODO)</param>
        /// <exception cref="System.ArgumentException">Cannot initialise a VCalendarBase class using any ObjectType except VEVENT, VTOTO or VJOURNAL</exception>
        protected CalendarBase(VersitObjectType type)
            : base(type)
        {
            if (type != VersitObjectType.VEVENT &&
                type != VersitObjectType.VTODO &&
                type != VersitObjectType.VJOURNAL)
            {
                throw new ArgumentException(Versit.Core.Properties.Resources.Exception_InvalidCalendarType, "type");
            }

            this.Fields.Add(new Property<DateTime?>("DTSTART", null));
            this.Fields.Add(new Text("LOCATION"));
            this.Fields.Add(new Text("SUMMARY"));
            this.Fields.Add(new Text("DESCRIPTION"));
            this.Fields.Add(new Text("CONTACT"));
            this.Fields.Add(new Property<int>("SEQUENCE", 0));
            this.Fields.Add(new Property<string[]>("RESOURCES", new string[] { }));
            this.Fields.Add(new Property<Coordinates>("GEO", new Coordinates()));

            // organiser is a standard field; use a VAttendee
            this.Fields.Add(new Attendee("ORGANIZER", null) { Role = RoleType.ORGANIZER });

            // initialise an empty collection of attendees
            this.FieldCollections.Add("ATTENDEES", new VPropertyCollection<Attendee>());

            // initialise an inner collection for any alarms
            this.InnerElements.Add(VersitObjectType.VALARM, new VersitObjectCollection());

            // initialise a collection for comments
            this.FieldCollections.Add("COMMENTS", new PropertyCollection());   // TODO: VComment

            // SEE http://www.kanzaki.com/docs/ical/
            // TODO: http://www.kanzaki.com/docs/ical/rrule.html
            // RecurrenceRules
            // RecurrenceDates
            // ExceptionRules
            // ExceptionDates
        }

        /// <summary>
        /// Gets or sets when this item begins.
        /// </summary>
        public DateTime? Starts
        {
            get { return GetPropertyValue<DateTime?>("DTSTART"); }
            set { SetPropertyValue<DateTime?>("DTSTART", value); }
        }

        /// <summary>
        /// Gets or sets the summary of this item.
        /// </summary>
        public string Summary
        {
            get { return GetPropertyValue<string>("SUMMARY"); }
            set { SetPropertyValue<string>("SUMMARY", value); }
        }

        /// <summary>
        /// Gets or sets the description of this item.
        /// </summary>
        public string Description
        {
            get { return GetPropertyValue<string>("DESCRIPTION"); }
            set { SetPropertyValue<string>("DESCRIPTION", value); }
        }

        /// <summary>
        /// Gets or sets the location of this item.
        /// </summary>
        public string Location
        {
            get { return GetPropertyValue<string>("LOCATION"); }
            set { SetPropertyValue<string>("LOCATION", value); }
        }

        /// <summary>
        /// Gets or sets contact information or alternately a reference to contact 
        /// information associated with the calendar component.
        /// </summary>
        public string Contact
        {
            get { return GetPropertyValue<string>("CONTACT"); }
            set { SetPropertyValue<string>("CONTACT", value); }
        }

        /// <summary>
        /// Gets or sets the co-ordinates of this item's location.
        /// </summary>
        public Coordinates Coordinates
        {
            get { return GetPropertyValue<Coordinates>("GEO"); }
            set { SetPropertyValue<Coordinates>("GEO", value); }
        }

        /// <summary>
        /// Gets or sets the equipment or resources needed in this item.
        /// </summary>
        /// <remarks>Optional</remarks>
        /// <example>EASEL;PROJECTOR;VCR</example>
        public IEnumerable<string> Resources
        {
            get { return GetPropertyValue<string[]>("RESOURCES"); }
            set { SetPropertyValue<string[]>("RESOURCES", value.ToArray()); }
        }

        /// <summary>
        /// Gets or sets the organizer of this item.
        /// </summary>
        public Attendee Organizer
        {
            get { return GetProperty<Attendee>("ORGANIZER"); }
            set { SetProperty("ORGANIZER", value); }
        }

        /// <summary>
        /// Gets a collection of attendees for this item.
        /// </summary>
        public VPropertyCollection<Attendee> Attendees
        {
            get { return (VPropertyCollection<Attendee>)FieldCollections["ATTENDEES"]; }
        }

        /// <summary>
        /// Gets a collection of alarms related to this item.
        /// </summary>
        public VersitObjectCollection Alarms
        {
            get { return this.InnerElements[VersitObjectType.VALARM]; ; }
        }
    }
}
