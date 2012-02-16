using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Versit.VCard.Test
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ContstructWithValues()
        {
            string firstName = "Keith";
            string lastName = "Williams";
            Name actual = new Name(firstName, lastName);
            Assert.AreEqual(firstName, actual.FirstName);
            Assert.AreEqual(lastName, actual.LastName);
        }

        [TestMethod]
        public void EmptyConstructor()
        {
            Name target = new Name();
            Assert.IsNotNull(target);
            Assert.AreEqual(5, target.Value.Length);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string firstName = "Keith";
            string lastName = "Williams";
            string expected = "N:Williams;Keith;;;";
            Name actual = new Name(firstName, lastName);
            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
