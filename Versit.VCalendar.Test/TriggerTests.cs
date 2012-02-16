using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versit.Core.VCalendar;
using Versit.Core;

namespace Versit.VCalendar.Test
{
    [TestClass]
    public class TriggerTests
    {
        [TestMethod]
        public void InitializeRelative()
        {
            var duration = new TimeSpan(0, -15, 0);
            var trigrel = new TriggerRelative(duration);

            Assert.AreEqual(duration, trigrel.Value);
            Assert.AreEqual("-PT15M", trigrel.ValueToString());
        }

        [TestMethod]
        public void InitializeAbsolute()
        {
            var date = DateTime.Today.AddDays(1);
            var trigabs = new TriggerAbsolute(date);

            Assert.AreEqual(date, trigabs.Value);
            Assert.AreEqual(date.ToString(VersitBase.DateTimeFormat), trigabs.ValueToString());
        }
    }
}
