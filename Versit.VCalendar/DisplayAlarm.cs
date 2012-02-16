//-----------------------------------------------------------------------
// <copyright file="VDisplayAlarm.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Versit.Core;
namespace Versit.VCalendar
{
    /// <summary>
    /// An alarm which displays a message.
    /// </summary>
    public class DisplayAlarm : AlarmBase
    {
        /// <summary>
        /// Initializes a new instance of the DisplayAlarm class.
        /// </summary>
        public DisplayAlarm()
            : this(new TriggerRelative(0, -15, 0), string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DisplayAlarm class.
        /// </summary>
        /// <param name="trigger">Trigger for this alarm</param>
        /// <param name="description">Text to display</param>
        public DisplayAlarm(ITrigger trigger, string description)
            : base(AlarmAction.DISPLAY, trigger)
        {
            this.Fields.Add(new Text("DESCRIPTION", description));
        }

        /// <summary>
        /// Gets or sets the text to be displayed when the alarm is triggered.
        /// </summary>
        public Text Description
        {
            get { return GetProperty<Text>("DESCRIPTION"); }
            set { SetProperty("DESCRIPTION", value); }
        }
    }
}
