using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versit.Core;

namespace Versit.VCalendar.Test
{
    [TestClass]
    public class TodoTests
    {
        [TestMethod]
        public void Instantiate()
        {
            var todo = new Todo();

            Assert.IsNotNull(todo);
            Assert.IsNotNull(todo.Attendees);
            Assert.IsNull(todo.Complete);
            Assert.IsNull(todo.Organizer.Value);

            Assert.AreEqual(0, todo.PercentComplete);
            Assert.AreEqual(0, todo.Priority);

            Assert.IsNotNull(todo.Alarms);
            Assert.IsFalse(todo.Alarms.Any());

            Assert.AreEqual(VersitObjectType.VTODO, todo.Type);
        }

        [TestMethod]
        public void Complete()
        {
            Todo target = new Todo();
            DateTime? expected = DateTime.Today.AddDays(-1);
            DateTime? actual;
            target.Complete = expected;
            actual = target.Complete;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PercentComplete()
        {
            Todo target = new Todo();
            decimal expected = 0.25M;
            decimal actual;
            target.PercentComplete = expected;
            actual = target.PercentComplete;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Priority()
        {
            Todo target = new Todo();
            int expected = 3;
            int actual;
            target.Priority = expected;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Status()
        {
            Todo target = new Todo();
            CalendarStatus expected = Versit.VCalendar.CalendarStatus.DECLINED;
            CalendarStatus actual;
            target.Status = expected;
            actual = target.Status;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void PercentComplete_ExceptionTest()
        {
            Todo todo = new Todo();
            todo.PercentComplete = 2;
        }

        [TestMethod]
        public void AddAttendee()
        {
            Todo todo = new Todo();
            var attendee1 = new Attendee(new Uri("mailto:joe@example.com")) {ParticipantStatus = CalendarStatus.ACCEPTED };
            var attendee2 = new Attendee(new Uri("mailto:bob@example.com")) { ParticipantStatus = CalendarStatus.DECLINED };

            todo.Attendees.Add(attendee1);

            Assert.AreEqual(1, todo.Attendees.Count);
            Assert.AreEqual(attendee1, todo.Attendees[0]);

            todo.Attendees.Add(attendee2);

            Assert.AreEqual(2, todo.Attendees.Count);
            Assert.AreEqual(attendee2, todo.Attendees[1]);
        }

        [TestMethod]
        public void RemoveAttendee()
        {
            Todo todo = new Todo();
            var attendee1 = new Attendee(new Uri("mailto:joe@example.com")) { ParticipantStatus = CalendarStatus.ACCEPTED };
            var attendee2 = new Attendee(new Uri("mailto:bob@example.com")) { ParticipantStatus = CalendarStatus.DECLINED };

            todo.Attendees.Add(attendee1);
            todo.Attendees.Add(attendee2);

            Assert.AreEqual(2, todo.Attendees.Count);

            todo.Attendees.Remove(attendee2);
            Assert.AreEqual(1, todo.Attendees.Count);
        }

        [TestMethod]
        public void Categories()
        {
            var todo = new Todo();

            Assert.IsNotNull(todo.Categories);
            Assert.AreEqual(0, todo.Categories.Count());

            todo.Categories = new string[] { "BUSINESS", "MEETING" };

            Assert.AreEqual(2, todo.Categories.Count());
            Assert.AreEqual("BUSINESS", todo.Categories.ToArray()[0]);
            Assert.AreEqual("MEETING", todo.Categories.ToArray()[1]);
        }

        [TestMethod]
        public void Organiser()
        {
            var target = new Todo();
            var expected = new Attendee(new Uri("mailto:keith@4verse.com"));
            Attendee actual;
            target.Organizer = expected;
            actual = target.Organizer;
            Assert.AreEqual(expected.Value, actual.Value);
        }

        [TestMethod]
        public void Description()
        {
            var target = new Todo();
            var expected = "Lorem ipsum dolor sit amet";
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
        }
    }
}
