using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Versit.VCalendar
{
    // see http://www.kanzaki.com/docs/ical/recur.html

    public class RecurrenceRuleBase
    {
        public RecurrenceRuleBase()
        {
        }

        public RecurrenceFrequency Frequency { get; set; }

        public int? Interval { get; set; }

        public int[] BySeconds { get; set; }

        public int[] ByHours { get; set; }

        public DayOfWeek[] ByDays { get; set; }

        public int[] ByMonthDays { get; set; }

        public int[] ByYearDays { get; set; }

        public int[] ByWeekNumbers { get; set; }

        public int[] ByMonths { get; set; }

        public int[] BySetPos { get; set; }

        public int WeekStart { get; set; }

        public override string ToString()
        {
            // TODO
            return base.ToString();
        }
    }
}
