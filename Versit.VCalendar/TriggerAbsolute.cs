//-----------------------------------------------------------------------
// <copyright file="TriggerAbsolute.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using Versit.Core;

    /// <summary>
    /// A trigger for an absolute date/time.
    /// </summary>
    public class TriggerAbsolute : Property<DateTime>, ITrigger
    {
        /// <summary>
        /// Initializes a new instance of the TriggerAbsolute class.
        /// </summary>
        public TriggerAbsolute()
            : this(new DateTime())
        {
        }

        /// <summary>
        /// Initializes a new instance of the TriggerAbsolute class.
        /// </summary>
        /// <param name="value">DateTime this trigger will activate</param>
        /// <remarks>Initializes an absolute trigger</remarks>
        public TriggerAbsolute(DateTime value)
            : base("TRIGGER", value)
        {
            this.Parameters.Add("VALUE", "DATE-TIME");
        }
    }
}
