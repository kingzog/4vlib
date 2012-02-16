using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Versit.VCalendar.Test
{
    [TestClass]
    public class EventTests
    {
        /// <summary>
        ///A test for VEvent Constructor
        ///</summary>
        [TestMethod]
        public void Constructor()
        {
            Event target = new Event();

            Assert.IsNotNull(target.Attendees, "Attendees collection is null");
        }

        [TestMethod]
        public void Attendees()
        {
            var target = new Event();

            Assert.AreEqual(0, target.Attendees.Count, "Attendees collection should be empty at initialisation");

            target.Attendees.Add(new Attendee(new Uri("mailto:keith@4verse.com")));

            Assert.AreEqual(1, target.Attendees.Count, "Attendee has not been added");

            target.Attendees.Remove(target.Attendees[0]);

            Assert.AreEqual(0, target.Attendees.Count, "Attendee has not been removed");
        }
    }
}
