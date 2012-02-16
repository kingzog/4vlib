namespace Versit.VCalendar
{
    /// <summary>
    /// The characteristic of an event that determines whether it appears to consume time on a calendar.
    /// </summary>
    /// <remarks>
    /// Events that consume actual time for the individual or resource associated with the calendar SHOULD 
    /// be recorded as OPAQUE, allowing them to be detected by free-busy time searches. Other events, 
    /// which do not take up the individual's (or resource's) time SHOULD be recorded as TRANSPARENT, 
    /// making them invisible to free-busy time searches.
    /// </remarks>
    public enum TransparencyType
    {
        /// <summary>
        /// Event is transparent or does not block on free/busy time searches.
        /// </summary>
        TRANSPARENT,

        /// <summary>
        /// Event is opaque or blocks on free/busy time searches.
        /// </summary>
        OPAQUE
    }
}
