using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versit.Core;

namespace Versit.VCard.Test
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void VContact_Initialise()
        {
            var contact = new Contact();

            Assert.AreEqual(VersitObjectType.VCARD, contact.Type);

            Assert.IsNotNull(contact.Addresses, "Address collection has not been initialised");
            Assert.IsNotNull(contact.TelephoneNumbers, "Telephone number collection has not been initialised");
            Assert.IsNotNull(contact.EmailAddresses, "Email address collection has not been initialised");
        }

        [TestMethod]
        public void VContact_Name()
        {
            var contact = new Contact();
            var name = "Keith Williams";
            contact.Name = name;

            Assert.AreEqual("Keith", contact.Name.FirstName);
            Assert.AreEqual("Williams", contact.Name.LastName);
        }

        [TestMethod]
        public void VContact_Addresses()
        {
            var contact = new Contact();
            var name = "Keith Williams";
            contact.Name = name;

            contact.Addresses.Add(new Address
            {
                StreetAddress = "Eurosafe House, Tribune Way",
                Locality = "York",
                PostalCode = "YO30 4RY",
                Region = "North Yorkshire",
                Country = "United Kingdom",
                AddressType = AddressType.WORK
            });

            contact.Addresses.Add(new Address
            {
                StreetAddress = "28 St Paul's Terrace",
                Locality = "York",
                PostalCode = "YO24 4BL",
                Region = "North Yorkshire",
                Country = "United Kingdom",
                AddressType = AddressType.HOME
            });

            Assert.AreEqual(2, contact.Addresses.Count);
        }

        [TestMethod]
        public void VContact_TelephoneNumbers()
        {
            var contact = new Contact();
            var name = "Keith Williams";
            contact.Name = name;

            contact.TelephoneNumbers.Add(new Telephone
            {
                CountryCode = 44,
                AreaCode = "01904",
                Value = "691515",
                TelephoneType = TelephoneType.WORK
            });

            contact.TelephoneNumbers.Add(new Telephone
            {
                CountryCode = 44,
                AreaCode = "01904",
                Value = "658796",
                TelephoneType = TelephoneType.HOME
            });

            contact.TelephoneNumbers.Add(new Telephone
            {
                CountryCode = 44,
                Value = "07941521644",
                TelephoneType = TelephoneType.CELL
            });

            Assert.AreEqual(3, contact.TelephoneNumbers.Count);
        }

        [TestMethod]
        public void VContact_EmailAddresses()
        {
            var contact = new Contact { Name = "Keith Williams" };
            contact.EmailAddresses.Add(new Email("keith@example.com"));

            Assert.AreEqual(1, contact.EmailAddresses.Count);
            Assert.AreEqual("keith@example.com", contact.EmailAddresses[0].ValueToString());
        }
    }
}
