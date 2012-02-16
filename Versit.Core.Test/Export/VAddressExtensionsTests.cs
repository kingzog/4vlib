using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourVerse.Library.Versit.Export;
using FourVerse.Library.Versit.VCard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourVerse.Library.Versit.Test.Export
{
    /// <summary>
    /// Summary description for VAddressExtensionsTests
    /// </summary>
    [TestClass]
    public class VAddressExtensionsTests
    {
        public VAddressExtensionsTests()
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
        public void ToHCard_Test()
        {
            var address = new VAddress
            {
                AddressType = AddressType.DOM,
                StreetAddress = "28 St. Paul's Terrace, Holgate",
                Locality = "York",
                Region = "North Yorkshire",
                PostalCode = "YO24 4BL",
                Country = "United Kingdom"
            };

            var htmlAddress = address.ToHCard("div");

            Assert.IsFalse(string.IsNullOrEmpty(htmlAddress));
        }
    }
}
