//-----------------------------------------------------------------------
// <copyright file="Journal.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using Versit.Core;

    /// <summary>
    /// Represents one or more descriptive text notes 
    /// associated with a particular calendar date.
    /// </summary>
    public class Journal : CalendarBase
    {
        // http://www.kanzaki.com/docs/ical/vjournal.html

        /// <summary>
        /// Initializes a new instance of the VJournal class.
        /// </summary>
        public Journal()
            : base(VersitObjectType.VJOURNAL)
        {
        }
    }
}
