using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleUserManagement.Domain.UserAggregate.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void Two_Same_Address_Should_Be_Equal()
        {
            var obj1 = new Address("1", "2", "3");
            var obj2 = new Address("1", "2", "3");
            Assert.AreEqual(obj1, obj2);
        }

        [TestMethod()]
        public void Two_Diff_Address_Should_Be_Equal()
        {
            var obj1 = new Address("1", "2", "3");
            var obj2 = new Address("a", "2", "3");
            Assert.AreNotEqual(obj1, obj2);
        }
    }
}