using Microsoft.EntityFrameworkCore;
using SampleUserManagement.Datalayer;
using SampleUserManagement.Domain.UserAggregate;
using SampleUserManagement.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleUserManagement.Repository.Implements
{
    public class UserRepository : BaseRepository<int, User>, IUserRepository
    {
        private readonly DbSet<Address> addresses;
        public UserRepository(UserManagementDbContext dbContext) : base(dbContext)
        {
            addresses = dbContext.Set<Address>();
        }

        public override async Task<User> Find(int id)
        {
            return await entities.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Address>> GetAllAddresses(int userId)
        {
            return await addresses.Where(x => x.UserId == userId).ToListAsync();
        }

        public Address AddAddress(User user, string fullAddress, string mobile, string email)
        {
            var newAddress = user.AddAddress(fullAddress, mobile, email);
            return newAddress;
        }

        public Address RemoveAddress(User user, int addressId)
        {
            var address = user.RemoveAddress(addressId);
            return address;
        }

        public async Task<User> GetUser(string username, string hashedPassword)
        {
            var user = await entities.FirstOrDefaultAsync(x => x.Username == username && x.Password == hashedPassword);
            return user;
        }
    }
}
