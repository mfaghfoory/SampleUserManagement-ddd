using Microsoft.EntityFrameworkCore;
using SampleUserManagement.Domain.UserAggregate;

namespace SampleUserManagement.Datalayer.Mappings
{
    public static class UserMapping
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedOnAdd();
                x.HasIndex(x => x.Username).IsUnique(true);

                x.Property(x => x.Username).IsRequired();
                x.Property(x => x.Password).IsRequired();
                x.Property(x => x.Fullname).IsRequired();

                x.HasMany(x => x.Addresses)
                    .WithOne()
                    .IsRequired()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.Metadata
                    .FindNavigation("Addresses")
                    .SetPropertyAccessMode(PropertyAccessMode.Field);

                x.HasMany(x => x.Addresses).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            

            modelBuilder.Entity<Address>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedOnAdd();

                x.Property(x => x.Email).IsRequired();
                x.Property(x => x.FullAddress).IsRequired();
                x.Property(x => x.Mobile).IsRequired();

                //x.HasOne(x => x.User).WithMany(x => x.Addresses).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
