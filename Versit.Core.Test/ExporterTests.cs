using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versit.Core.VCard;
using System.IO;

namespace Versit.Core.Test
{
    /// <summary>
    /// Summary description for ExporterTests
    /// </summary>
    [TestClass]
    public class ExporterTests
    {
        public ExporterTests()
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
        public void Exporter_VContact()
        {
            var contact = new VContact
            {
                Name = "Keith Williams",
                FormattedName = "Williams, Keith",
                Birthday = new DateTime(1981, 4, 23),
                Title = "Captain",
                Organization = "4verse",
                Note = "Lorem ipsum dolor sit amet."
            };

            contact.Addresses.Add(new VAddress
            {
                StreetAddress = "28 St. Paul's Terrace",
                Locality = "York",
                Region = "North Yorkshire",
                PostalCode = "YO24 4BL",
                Country = "UNITED KINGDOM"
            });

            contact.TelephoneNumbers.Add(new VTelephone
            {
                TelephoneType = TelephoneType.CELL,
                Value = "07941521644",
                CountryCode = 44
            });

            contact.TelephoneNumbers.Add(new VTelephone
            {
                TelephoneType = TelephoneType.HOME,
                Value = "658796",
                AreaCode = "01904",
                CountryCode = 44
            });

            contact.EmailAddresses.Add(new VEmail
            {
                EmailType = EmailType.INTERNET,
                Value = "keith@4verse.com"
            });

            contact.EmailAddresses.Add(new VEmail
            {
                EmailType = EmailType.INTERNET,
                Value = "keith@kingzog.co.uk"
            });

            var exporter = new Exporter(contact);
            //var result = exporter.Export();

            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".vcf");
            exporter.SaveAs(path);
        }
    }
}
