using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versit.Core;
using Versit.Core.VCard;
using System.IO;

namespace Versit.Core.Test.Export
{
    /// <summary>
    /// Summary description for ExportVCardTests
    /// </summary>
    [TestClass]
    public class ExportVCardTests
    {
        public ExportVCardTests()
        {

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
        public void ExportVCard()
        {
            var vcard = new VContact();
            vcard.Name = "Keith Williams";
            vcard.Organization = "Eurosafe UK";
            vcard.Title = "IT Manager";
            vcard.FormattedName = "Mr. Keith Williams";

            var exporter = new Versit.Core.Exporter(vcard);
            var result = exporter.Export();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExportToDisk()
        {
            var vcard = new VContact();
            vcard.Name = "Keith Williams";
            vcard.Name.Title = "Mr.";
            vcard.Name.Suffix = "BA (Hons)";
            vcard.Name.MiddleName = "Arthur Elliot";
            vcard.FormattedName = "Williams, Keith";

            vcard.Organization = "Eurosafe UK";
            vcard.Title = "IT Manager";
            vcard.Role = "Manager";
            vcard.Note = "Some notes on Keith";

            vcard.UniqueIdentifier = Guid.NewGuid();
            vcard.Birthday = new DateTime(1981, 4, 23);

            var address = new VAddress
            {
                AddressType = AddressType.DOM,
                StreetAddress = "28 St. Paul's Terrace, Holgate",
                Locality = "York",
                Region = "North Yorkshire",
                PostalCode = "YO24 4BL",
                Country = "United Kingdom"
            };

            var tel = new VTelephone
            {
                CountryCode = 44,
                AreaCode = "01904",
                Value = "658 796",
                TelephoneType = TelephoneType.HOME
            };

            vcard.Addresses.Add(address);
            vcard.TelephoneNumbers.Add(tel);

            var exporter = new Versit.Core.Exporter(vcard);
            var result = exporter.Export();

            var file = new FileInfo(Path.Combine(Path.GetTempPath(), vcard.UniqueIdentifier.ToString() + ".vcf"));
            StreamWriter sw = file.CreateText();
            sw.Write(result);
            sw.Close();
        }
    }
}
