using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourVerse.Library.Versit.Import;
using FourVerse.Library.Versit.VCalendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourVerse.Library.Versit.Test
{
    /// <summary>
    /// Summary description for ParserTests
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        public ParserTests()
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
        public void GetPropertyName_Test()
        {
            var lineToParse = "PROPERTY:Value";
            var value = Parser.GetPropertyName(lineToParse);

            Assert.AreEqual("PROPERTY", value, "Parsed name was not correctly returned");
        }

        [TestMethod]
        public void GetPropertyValue_Test()
        {
            var lineToParse = "PROPERTY:Value";
            var value = Parser.GetPropertyValue(lineToParse);

            Assert.AreEqual("Value", value, "Parsed value was not correctly returned");
        }

        [TestMethod]
        public void ParseProperty_Test()
        {
            var lineToParse = "SUBJECT;ENCODING=QUOTED_PRINTABLE;CLASS=PUBLIC:This is a test";
            var result = Parser.ParseProperty<string>(lineToParse);

            Assert.AreEqual("SUBJECT", result.Name);
            Assert.AreEqual("This is a test", result.Value);
        }

        [TestMethod]
        public void ParsePropertyInt_Test()
        {
            var lineToParse = "NUMBER:20000";
            var result = Parser.ParseProperty<int>(lineToParse);

            Assert.AreEqual(20000, result.Value);
        }

        [TestMethod]
        public void ParsePropertyDuration_Test()
        {
            var duration = new Duration(new TimeSpan(2, 3, 10, 30));
            var durationString = duration.ToString();

            var lineToParse = string.Concat("REPEAT:", durationString);
            var result = Parser.ParseProperty<Duration>(lineToParse);

            Assert.AreEqual(duration, result.Value);
            Assert.AreEqual(durationString, result.ValueToString());
        }

        [TestMethod]
        public void ParsePropertyDateTime_Test()
        {
            var date = DateTime.Now;
            var dateString = date.ToString("o");

            var lineToParse = string.Concat("BDAY:", dateString);
            var result = Parser.ParseProperty<DateTime>(lineToParse);

            Assert.AreEqual(date, result.Value);
            Assert.AreEqual(dateString, result.ValueToString());
        }

        [TestMethod]
        public void ParsePropertyArray_Test()
        {
            var array = new string[] { "28 St Paul's Terrace", "York", "North Yorkshire", "YO24 4BL" };
            var arrayString = string.Join(";", array);

            var lineToParse = string.Concat("ADR:", arrayString);
            var result = Parser.ParseProperty<string[]>(lineToParse);

            Assert.AreEqual(array.Length, result.Value.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ParsePropertyException_Test()
        {
            var lineToParse = "NUMBER:This is not a number";
            var result = Parser.ParseProperty<int>(lineToParse);
        }

        [TestMethod]
        public void Fold_Test()
        {
            var input = "DESCRIPTION:In Xanadu did Kubla Khan a stately pleasure-dome decree/Where Alph the sacred river ran through caverns measureless to man/Down to a sunless sea";
            var length = input.Length;

            var folded = Parser.Fold(input);

            var lines = folded.Split('\n');

            foreach (var line in lines)
            {
                Assert.IsTrue(line.Length <= Parser.MaxLineLength, "Line is " + line.Length + ", should be less than " + Parser.MaxLineLength);
            }
        }
    }
}
