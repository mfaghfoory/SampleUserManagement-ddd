using Microsoft.EntityFrameworkCore;
using SampleUserManagement.Common;
using SampleUserManagement.Domain.UserAggregate;

namespace SampleUserManagement.Datalayer.Seeders
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User("admin", "123".ComputeSha256Hash(), "administrator").SetId(-1));

            modelBuilder.Entity<Address>().HasData(new Address("Iran - Tabriz", "0935999999", "test@gmail.com").SetId(-1).SetUserId(-1));
        }
    }
}
