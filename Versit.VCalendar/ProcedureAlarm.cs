//-----------------------------------------------------------------------
// <copyright file="VProcedureAlarm.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core;

    /// <summary>
    /// An alarm which triggers a procedure.
    /// </summary>
    public class ProcedureAlarm : AlarmBase
    {
        /// <summary>
        /// Initializes a new instance of the ProcedureAlarm class.
        /// </summary>
        public ProcedureAlarm()
            : this(new TriggerRelative(0, -15, 0), new AttachUri())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProcedureAlarm class.
        /// </summary>
        /// <param name="trigger">Trigger for this alarm</param>
        /// <param name="attach">Procedure to trigger</param>
        public ProcedureAlarm(ITrigger trigger, IAttachment attach)
            : base(AlarmAction.PROCEDURE, trigger)
        {
            this.Fields.Add(new Property<IAttachment>("ATTACH", attach));
        }

        /// <summary>
        /// Gets or sets a Uri pointing to a prodecure resource to
        /// invoke when this alarm is triggered.
        /// </summary>
        public IAttachment Attach
        {
            get { return GetProperty<IAttachment>("ATTACH"); }
            set { SetProperty("ATTACH", value); }
        }
    }
}
