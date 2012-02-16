using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Versit.Core.Test
{
    [TestClass]
    public class PropertyTests
    {
        [TestMethod]
        public void Constructor()
        {
            var property = new Property<string>("TEST", "Test string");

            Assert.IsNotNull(property);
            Assert.IsNotNull(property.Parameters);
            Assert.AreEqual(0, property.Parameters.Count);

            Assert.AreEqual("TEST", property.Name);
            Assert.AreEqual("Test string", property.Value);
        }

        [TestMethod]
        public void SetParameter()
        {
            var property = new Property<string>("TEST", "Test string");

            Assert.AreEqual(0, property.Parameters.Count);

            property.SetParameter("ISTEST", true);

            Assert.AreEqual(1, property.Parameters.Count);
            Assert.AreEqual(true.ToString(), property.GetParameter("ISTEST"));
        }

        [TestMethod]
        public void GetParameter()
        {
            var property = new Property<string>("TEST", "Test string");
            property.SetParameter("ISTEST", true);
            Assert.AreEqual(true.ToString(), property.GetParameter("ISTEST"));
        }

        [TestMethod]
        public void GetUnSetParameter()
        {
            var property = new Property<string>("TEST", "Test string");
            Assert.AreEqual(string.Empty, property.GetParameter("ISTEST"));
        }

        [TestMethod]
        public void GetEnumParameter()
        {
            var property = new Property<string>("TEST", "Test string");
            property.SetParameter("ENCODING", EncodingType.BASE64);
            Assert.AreEqual(EncodingType.BASE64, property.GetEnumParameter<EncodingType>("ENCODING"));
        }

        [TestMethod]
        public void GetUnSetEnumParameter()
        {
            var property = new Property<string>("TEST", "Test string");
            Assert.AreEqual(EncodingType.QUOTEDPRINTABLE, property.GetEnumParameter<EncodingType>("ENCODING"));
        }

        [TestMethod]
        public void CopyFrom()
        {
            var oldValue = "Test string";
            var newValue = "New string";

            var target = new Property<string>("TEST", oldValue);
            var replacement = new Property<string>("TEST", newValue);

            replacement.Parameters.Add("ENCODING", EncodingType.QUOTEDPRINTABLE.ToString());
            replacement.Parameters.Add("LANGUAGE", "en-GB");

            target.CopyFrom(replacement);

            Assert.AreEqual(newValue, target.Value);
            Assert.AreEqual(replacement.Parameters, target.Parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyFrom_ExceptionTest()
        {
            var target = new Property<string>("TEST", "Test string");
            var replacement = new Property<int>("TEST", 100);

            target.CopyFrom(replacement);
        }
    }
}
