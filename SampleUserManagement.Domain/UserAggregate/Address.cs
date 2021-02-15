namespace SampleUserManagement.Domain.UserAggregate
{
    public class Address
    {
        public Address(string fullAddress, string mobile, string email)
        {
            FullAddress = fullAddress;
            Mobile = mobile;
            Email = email;
        }

        /// <summary>
        /// This is just for testing purposes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address SetId(int id)
        {
            // Some valdations here
            Id = id;
            return this;
        }

        public Address SetUserId(int userId)
        {
            // Some valdations here
            UserId = userId;
            return this;
        }

        public int Id { get; private set; }

        public int UserId { get; private set; }

        public string FullAddress { get; private set; }

        public string Mobile { get; private set; }

        public string Email { get; private set; }

        public User User { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   FullAddress == address.FullAddress &&
                   Mobile == address.Mobile &&
                   Email == address.Email &&
                   UserId == address.UserId;
        }

        public static bool operator ==(Address obj1, Address obj2)
        {           
            if (ReferenceEquals(obj1, null) && ReferenceEquals(obj2, null)) return true;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Address obj1, Address obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
