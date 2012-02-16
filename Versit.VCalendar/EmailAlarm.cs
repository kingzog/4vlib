//-----------------------------------------------------------------------
// <copyright file="VEmailAlarm.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Versit.Core;
namespace Versit.VCalendar
{
    /// <summary>
    /// An alarm which sends an email to a group of attendees.
    /// </summary>
    public class EmailAlarm : AlarmBase
    {
        /// <summary>
        /// Initializes a new instance of the EmailAlarm class.
        /// </summary>
        public EmailAlarm()
            : this(new TriggerRelative(0, -15, 0), string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the EmailAlarm class.
        /// </summary>
        /// <param name="trigger">Trigger for this alarm</param>
        /// <param name="summary">Text for the email subject</param>
        /// <param name="description">Text for the email body</param>
        public EmailAlarm(ITrigger trigger, string summary, string description)
            : base(AlarmAction.EMAIL, trigger)
        {
            this.Fields.Add(new Text("DESCRIPTION", description));
            this.Fields.Add(new Text("SUMMARY", summary));
            this.FieldCollections.Add("ATTENDEES", new VPropertyCollection<Attendee>());
            this.FieldCollections.Add("ATTACHMENTS", new VPropertyCollection<IAttachment>());
        }

        /// <summary>
        /// Gets or sets the text to be used as the message body.
        /// </summary>
        public Text Description
        {
            get { return GetProperty<Text>("DESCRIPTION"); }
            set { SetProperty("DESCRIPTION", value); }
        }

        /// <summary>
        /// Gets or sets the text to be used as the message subject.
        /// </summary>
        public Text Summary
        {
            get { return GetProperty<Text>("SUMMARY"); }
            set { SetProperty("SUMMARY", value); }
        }

        /// <summary>
        /// Gets a collection of recipients for this alarm.
        /// </summary>
        public VPropertyCollection<Attendee> Attendees
        {
            get { return (VPropertyCollection<Attendee>)FieldCollections["ATTENDEES"]; }
        }

        /// <summary>
        /// Gets a collection of attachments for this alarm.
        /// </summary>
        public VPropertyCollection<IAttachment> Attachments
        {
            get { return (VPropertyCollection<IAttachment>)FieldCollections["ATTACHMENTS"]; }
        }
    }
}
