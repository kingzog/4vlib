using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Versit.VCalendar.Test
{
    [TestClass()]
    public class AttendeeTest
    {
        [TestMethod()]
        public void VAttendee_ParticipantStatus()
        {
            Attendee target = new Attendee(null);
            CalendarStatus expected = CalendarStatus.DECLINED;
            CalendarStatus actual;
            target.ParticipantStatus = expected;
            actual = target.ParticipantStatus;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void VAttendee_ExpectType()
        {
            Attendee target = new Attendee(null);
            ExpectType expected = ExpectType.IMMEDIATE;
            ExpectType actual;
            target.Expect = expected;
            actual = target.Expect;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void VAttendee_Value()
        {
            Attendee target = new Attendee(null);
            Uri expected = new Uri("mailto:harry@example.net");
            Uri actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void VAttendee_NewAttendee()
        {
            string email = "mailto:bill@example.com";
            CalendarStatus partstat = CalendarStatus.CONFIRMED;
            Attendee actual = new Attendee(new Uri(email)) { ParticipantStatus = partstat };
            Assert.AreEqual(email, actual.Value.AbsoluteUri);
            Assert.AreEqual(partstat, actual.ParticipantStatus);
        }

        [TestMethod()]
        public void VAttendee_Constructor()
        {
            Attendee target = new Attendee(null);
            Assert.IsNotNull(target);
            Assert.IsNull(target.Value);
            Assert.AreEqual(CalendarStatus.UNKNOWN, target.ParticipantStatus);
            Assert.AreEqual(CuType.UNKNOWN, target.CalendarUserType);
            Assert.AreEqual(ExpectType.UNKNOWN, target.Expect);
            Assert.AreEqual("NO", target.GetParameter("RSVP"));
        }

        [TestMethod]
        public void VAttendee_DisplayName()
        {
            Attendee target = new Attendee(null);
            string expected = "Harry Truman";
            string actual;
            target.DisplayName = expected;
            actual = target.DisplayName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VAttendee_Rsvp()
        {
            Attendee target = new Attendee(null);
            bool expected = true;
            bool actual;
            target.Rsvp = expected;
            actual = target.Rsvp;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("YES", target.GetParameter("RSVP"));
        }
    }
}
