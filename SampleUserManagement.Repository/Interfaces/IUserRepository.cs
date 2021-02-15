using SampleUserManagement.Domain.UserAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleUserManagement.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<int, User>
    {
        Task<ICollection<Address>> GetAllAddresses(int userId);

        Address AddAddress(User user, string fullAddress, string mobile, string email);

        Address RemoveAddress(User user, int addressId);

        Task<User> GetUser(string username, string hashedPassword);
    }
}
