using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleUserManagement.Common;

namespace SampleUserManagement.Domain.UserAggregate.Tests
{
    [TestClass()]
    public class HelpersTests
    {
        [TestMethod()]
        [DataTestMethod]
        [DataRow("")]
        [DataRow("@")]
        [DataRow("-")]
        [DataRow("@.com")]
        [DataRow("@mail.com")]
        [DataRow("mail.com")]
        public void Check_IsValidEmail_Should_Invalid(string str)
        {
            var v1 = str.IsValidEmail();
            Assert.AreEqual(v1, false);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow("a@b.com")]
        [DataRow("test@mail.com")]
        public void Check_IsValidEmail_Should_Valid(string str)
        {
            var v1 = str.IsValidEmail();
            Assert.AreEqual(v1, true);
        }

        [TestMethod()]
        public void Check_ComputeSha256Hash_1()
        {
            var v1 = "".ComputeSha256Hash();
            Assert.AreEqual(v1, string.Empty);
        }

        [TestMethod()]
        public void Check_ComputeSha256Hash_2()
        {
            var v1 = "1".ComputeSha256Hash();
            Assert.IsTrue(v1.Length > 1);
        }
    }
}