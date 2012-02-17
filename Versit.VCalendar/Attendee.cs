//-----------------------------------------------------------------------
// <copyright file="Attendee.cs" company="4verse">
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
    /// Represents an attendee of an event or an assignee of a task.
    /// </summary>
    public class Attendee : CalAddress
    {
        /// <summary>
        /// Initializes a new instance of the Attendee class.
        /// </summary>
        /// <param name="attendee">URI of the attendee</param>
        /// <example>
        ///   <code>
        ///     var attendee = new VAttendee(new Uri("mailto:bill@example.com"));
        ///   </code>
        /// </example>
        public Attendee(Uri attendee)
            : base("ATTENDEE", attendee)
        {
            this.InitialiseParameters();
        }

        /// <summary>
        /// Initializes a new instance of the Attendee class.
        /// </summary>
        /// <param name="name">Name of this property</param>
        /// <param name="attendee">URI of the attendee</param>
        public Attendee(string name, Uri attendee)
            : base(name, attendee)
        {
            this.InitialiseParameters();
        }

        /// <summary>
        /// Gets or sets the type of calendar user.
        /// </summary>
        public CuType CalendarUserType
        {
            get { return this.GetEnumParameter<CuType>("CUTYPE"); }
            set { this.SetParameter("CUTYPE", value); }
        }

        /// <summary>
        /// Gets or sets the participating status of the attendee.
        /// </summary>
        public CalendarStatus ParticipantStatus
        {
            get { return this.GetEnumParameter<CalendarStatus>("PARTSTAT"); }
            set { this.SetParameter("PARTSTAT", value); }
        }

        /// <summary>
        /// Gets or sets the role of this attendee on the event.
        /// </summary>
        public RoleType Role
        {
            get { return this.GetEnumParameter<RoleType>("ROLE"); }
            set { this.Parameters["ROLE"] = value.ToString(); }
        }

        /// <summary>
        /// Gets or sets the type of response expected from the attendee.
        /// </summary>
        public ExpectType Expect
        {
            get { return this.GetEnumParameter<ExpectType>("EXPECT"); }
            set { this.Parameters["EXPECT"] = value.ToString(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the attendee is 
        /// required to respond to the invitation.
        /// </summary>
        public bool Rsvp
        {
            get { return this.GetParameter("RSVP") == "YES"; }
            set { this.SetParameter("RSVP", (value ? "YES" : "NO")); }
        }

        /// <summary>
        /// Gets or sets the displayable name associated with this 
        /// calendar address.
        /// </summary>
        public string DisplayName
        {
            get { return this.GetParameter("CN"); }
            set { this.SetParameter("CN", value); }
        }

        /// <summary>
        /// Initialises common parameters on this object.
        /// </summary>
        /// <remarks>
        /// Called from the constructors; used to prevent repeating
        /// this code for both constructors.
        /// </remarks>
        private void InitialiseParameters()
        {
            this.Parameters.Clear();
            this.Parameters.Add("CUTYPE", CuType.UNKNOWN.ToString());
            this.Parameters.Add("PARTSTAT", CalendarStatus.UNKNOWN.ToString());
            this.Parameters.Add("ROLE", RoleType.UNKNOWN.ToString());
            this.Parameters.Add("EXPECT", ExpectType.UNKNOWN.ToString());
            this.Parameters.Add("RSVP", "NO");
            this.Parameters.Add("CN", string.Empty);
        }
    }
}
