using Versit.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Versit.Core.Test
{
    [TestClass()]
    public class VBaseTest
    {
        /*
        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Version;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UniqueIdentifier
        ///</summary>
        [TestMethod()]
        public void UniqueIdentifierTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            Guid expected = new Guid(); // TODO: Initialize to an appropriate value
            Guid actual;
            target.UniqueIdentifier = expected;
            actual = target.UniqueIdentifier;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void TypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            ObjectType expected = new ObjectType(); // TODO: Initialize to an appropriate value
            ObjectType actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Revision
        ///</summary>
        [TestMethod()]
        public void RevisionTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.Revision = expected;
            actual = target.Revision;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InnerElements
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void InnerElementsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            VObjectCollection expected = null; // TODO: Initialize to an appropriate value
            VObjectCollection actual;
            target.InnerElements = expected;
            actual = target.InnerElements;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        public void FieldsTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            VPropertyCollection actual;
            actual = target.Fields;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldCollections
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void FieldCollectionsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            Dictionary<string, VPropertyCollection> expected = null; // TODO: Initialize to an appropriate value
            Dictionary<string, VPropertyCollection> actual;
            target.FieldCollections = expected;
            actual = target.FieldCollections;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Class
        ///</summary>
        [TestMethod()]
        public void ClassTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            ClassificationType expected = new ClassificationType(); // TODO: Initialize to an appropriate value
            ClassificationType actual;
            target.Class = expected;
            actual = target.Class;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual VBase CreateVBase()
        {
            // TODO: Instantiate an appropriate concrete class.
            VBase target = null;
            return target;
        }

        /// <summary>
        ///A test for Categories
        ///</summary>
        [TestMethod()]
        public void CategoriesTest()
        {
            VBase target = CreateVBase(); // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            target.Categories = expected;
            actual = target.Categories;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetPropertyValue
        ///</summary>
        public void SetPropertyValueTestHelper<T>()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            T value = default(T); // TODO: Initialize to an appropriate value
            target.SetPropertyValue<T>(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void SetPropertyValueTest()
        {
            SetPropertyValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for SetProperty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void SetPropertyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IVProperty value = null; // TODO: Initialize to an appropriate value
            target.SetProperty(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPropertyValue
        ///</summary>
        public void GetPropertyValueTestHelper<T>()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = target.GetPropertyValue<T>(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void GetPropertyValueTest()
        {
            GetPropertyValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetProperty
        ///</summary>
        public void GetPropertyTestHelper<T>()
            where T : IVProperty
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VBase_Accessor target = new VBase_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = target.GetProperty<T>(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual VBase_Accessor CreateVBase_Accessor()
        {
            // TODO: Instantiate an appropriate concrete class.
            VBase_Accessor target = null;
            return target;
        }

        [TestMethod()]
        [DeploymentItem("Versit.Core.dll")]
        public void GetPropertyTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetPropertyTestHelper<T>() with appropriate type parameters.");
        }
        
        */
    }
}
