using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(u => u.Role)
                   .IsRequired();


            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "mrossi@diner.it",
                    Password = "1234",
                    Role = UserRole.Caterer
                },
                new User
                {
                    Id = 2,
                    Email = "pbianchi@mail.it",
                    Password = "5678",
                    Role = UserRole.Customer
                },
                new User
                {
                    Id = 3,
                    Email = "gverdi@mail.it",
                    Password = "9876",
                    Role = UserRole.Customer
                }
            );
        }
    }
}
