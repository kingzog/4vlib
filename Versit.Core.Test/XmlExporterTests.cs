using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourVerse.Library.Versit.VCard;

namespace FourVerse.Library.Versit.Test
{
    /// <summary>
    /// Summary description for XmlExporterTests
    /// </summary>
    [TestClass]
    public class XmlExporterTests
    {
        public XmlExporterTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Export_Test()
        {
            var contact = new VContact
            {
                Name = new VName("Keith", "Williams"),
                Organization = "4verse",
                Title = "Captain",
                Birthday = new DateTime(1981, 4, 23)
            };

            contact.EmailAddresses.Add(new VEmail("keith@4verse.com"));
            contact.EmailAddresses.Add(new VEmail("keith@kingzog.co.uk"));

            contact.TelephoneNumbers.Add(new VTelephone
            {
                CountryCode = 44,
                AreaCode = "01904",
                Value = "691515",
                TelephoneType = TelephoneType.WORK
            });

            contact.TelephoneNumbers.Add(new VTelephone
            {
                CountryCode = 44,
                AreaCode = "01904",
                Value = "658796",
                TelephoneType = TelephoneType.HOME
            });

            contact.TelephoneNumbers.Add(new VTelephone
            {
                CountryCode = 44,
                Value = "07941521644",
                TelephoneType = TelephoneType.CELL
            });

            contact.Addresses.Add(new VAddress
            {
                StreetAddress = "28 St Paul's Terrace",
                Locality = "York",
                PostalCode = "YO24 4BL",
                Region = "North Yorkshire",
                Country = "United Kingdom",
                AddressType = AddressType.HOME
            });

            var xex = new XmlExporter(contact);
            var result = xex.Export();

            Assert.IsNotNull(result);
            // TODO: write full tests
        }
    }
}
