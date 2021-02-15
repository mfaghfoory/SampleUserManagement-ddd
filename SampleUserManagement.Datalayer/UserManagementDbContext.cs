using Microsoft.EntityFrameworkCore;
using SampleUserManagement.Datalayer.Mappings;
using SampleUserManagement.Datalayer.Seeders;

namespace SampleUserManagement.Datalayer
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("test-db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Mappers"
            UserMapping.Map(modelBuilder);
            #endregion

            #region "Seeders"
            UserSeed.Seed(modelBuilder);
            #endregion
        }
    }
}
