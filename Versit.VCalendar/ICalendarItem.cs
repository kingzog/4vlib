//-----------------------------------------------------------------------
// <copyright file="ICalendarItem.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using System.Collections.Generic;
    using Versit.Core;

    /// <summary>
    /// A calendar item.
    /// </summary>
    public interface ICalendarItem : IVersitObject
    {
        /// <summary>
        /// Gets or sets the summary text.
        /// </summary>
        string Summary { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets when this item starts.
        /// </summary>
        DateTime? Starts { get; set; }

        /// <summary>
        /// Gets or sets the co-ordinates.
        /// </summary>
        Coordinates Coordinates { get; set; }
        
        /// <summary>
        /// Gets or sets the organiser.
        /// </summary>
        Attendee Organizer { get; set; }

        /// <summary>
        /// Gets or sets any associated resources.
        /// </summary>
        IEnumerable<string> Resources { get; set; }

        /// <summary>
        /// Gets a collection of attendees.
        /// </summary>
        VPropertyCollection<Attendee> Attendees { get; }
    }
}
