using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Versit.VCalendar.Test
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void DisplayAlarm()
        {
            var alarm = new DisplayAlarm(new TriggerRelative(0, -15, 0), "Hello, world!");

            Assert.IsNotNull(alarm);
            Assert.AreEqual(new TimeSpan(0, -15, 0), ((TriggerRelative)alarm.Trigger).Value);
        }
    }
}
