using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SampleUserManagement.Domain.UserAggregate.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void Invalid_User_Raise_Error()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new User("", "", ""));
            Assert.ThrowsException<ArgumentNullException>(() => new User("1", "", ""));
            Assert.ThrowsException<ArgumentNullException>(() => new User("", "2", ""));

            var user = PrepareTestUser();
            Assert.ThrowsException<ArgumentNullException>(() => user.SetUsername(""));
            Assert.ThrowsException<ArgumentNullException>(() => user.SetPassword(""));
            Assert.ThrowsException<ArgumentNullException>(() => user.SetFullname(""));

        }

        [TestMethod()]
        public void Invalid_Address_Should_Raise_Error()
        {
            var user = PrepareTestUser();
            Assert.ThrowsException<ArgumentNullException>(() => user.AddAddress("", "", ""));
            Assert.ThrowsException<ArgumentNullException>(() => user.AddAddress("", "2", "3"));
            Assert.ThrowsException<ArgumentNullException>(() => user.AddAddress("", "", "1"));
            Assert.ThrowsException<ArgumentNullException>(() => user.AddAddress("1", "", ""));
            Assert.ThrowsException<ArgumentNullException>(() => user.AddAddress("1", "2", ""));
        }

        [TestMethod()]
        public void Duplicate_Address_Should_Raise_Error()
        {
            var user = PrepareTestUser();
            user.AddAddress("a", "123", "a@b.com");
            Assert.ThrowsException<Exception>(() => user.AddAddress("a", "123", "a@b.com"));

        }

        [TestMethod()]
        public void Invalid_AddressId_Should_Raise_Error()
        {
            var user = PrepareTestUser();
            var addr1 = user.AddAddress("a", "123", "a@b.com");
            var addr2 = user.AddAddress("b", "123", "a@b.com");
            Assert.ThrowsException<Exception>(() => user.RemoveAddress(-100));
        }

        [TestMethod()]
        public void Invalid_Email_Should_Raise_Error()
        {
            var user = PrepareTestUser();
            Assert.ThrowsException<ArgumentException>(() => user.AddAddress("1", "2", "abc"));
        }

        [TestMethod()]
        public void Check_Add_Address_Functionality()
        {
            var user = PrepareTestUser();
            user.AddAddress("a", "b", "a@mail.com");            
        }

        [TestMethod()]
        public void Duplicate_Address()
        {
            var user = PrepareTestUser();
            Assert.ThrowsException<Exception>(() =>
            {
                user.AddAddress("a", "b", "a@mail.com");
                user.AddAddress("a", "b", "a@mail.com");
            });
            
        }

        User PrepareTestUser()
        {
            return new User("admin", "admin", "test");
        }
    }
}