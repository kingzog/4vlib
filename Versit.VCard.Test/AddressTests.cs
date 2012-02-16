using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Versit.VCard.Test
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void VAddressConstructor()
        {
            Address target = new Address();
            Assert.IsNotNull(target.Value, "Initialised VAddress has a null value");
            Assert.AreEqual(9, target.Value.Length, "Initialised VAddress should be a string[9] object");
        }
    }
}
