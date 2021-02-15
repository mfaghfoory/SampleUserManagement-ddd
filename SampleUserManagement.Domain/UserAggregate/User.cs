using SampleUserManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleUserManagement.Domain.UserAggregate
{
    public class User : BaseEntity<int>
    {
        public User(string username, string password, string fullname)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrEmpty(fullname)) throw new ArgumentNullException(nameof(fullname));

            Username = username;
            Password = password;
            Fullname = fullname;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Fullname { get; private set; }

        /// <summary>
        /// This is just for testing purposes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User SetId(int id)
        {
            // Some valdations here
            Id = id;
            return this;
        }

        public User SetUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            Username = username;
            return this;
        }

        public User SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
            Password = password;
            return this;
        }

        public User SetFullname(string fullname)
        {
            if (string.IsNullOrEmpty(fullname)) throw new ArgumentNullException(nameof(fullname));
            Fullname = fullname;
            return this;
        }

        public Address AddAddress(string fullAddress, string mobile, string email)
        {
            if (string.IsNullOrEmpty(fullAddress)) throw new ArgumentNullException(nameof(fullAddress));
            if (string.IsNullOrEmpty(mobile)) throw new ArgumentNullException(nameof(mobile));
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            if (!email.IsValidEmail()) throw new ArgumentException("Email is not valid");

            var newAddress = new Address(fullAddress, mobile, email);
            if (addresses.Any(x => x == newAddress))
                throw new Exception("Duplicate address found");

            addresses.Add(newAddress);
            return newAddress;
        }

        public Address RemoveAddress(int addressId)
        {
            var address = addresses.FirstOrDefault(x => x.Id == addressId);
            if (address == null) throw new Exception("Address does not exist");
            addresses.Remove(address);
            return address;
        }

        private List<Address> addresses = new List<Address>();

        public IReadOnlyList<Address> Addresses => addresses.ToList();
    }
}
