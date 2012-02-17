//-----------------------------------------------------------------------
// <copyright file="AudioAlarm.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core;

    /// <summary>
    /// An alarm which plays an audio file.
    /// </summary>
    public class AudioAlarm : AlarmBase
    {
        /// <summary>
        /// Initializes a new instance of the AudioAlarm class.
        /// </summary>
        public AudioAlarm()
            : this(new TriggerRelative(0, -15, 0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the AudioAlarm class.
        /// </summary>
        /// <param name="trigger">Trigger for this alarm</param>
        public AudioAlarm(ITrigger trigger)
            : base(AlarmAction.AUDIO, trigger)
        {
            this.Fields.Add(new Property<IAttachment>("ATTACH", null));
        }

        /// <summary>
        /// Gets or sets a Uri pointing to a sound resource to play
        /// when this alarm is triggered.
        /// </summary>
        public IAttachment Attach
        {
            get { return GetProperty<IAttachment>("ATTACH"); }
            set { SetProperty("ATTACH", value); }
        }
    }
}
