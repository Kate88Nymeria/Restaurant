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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.MenuName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(m => m.Dishes)
                   .WithOne(d => d.Menu);


            builder.HasData(
                new Menu
                {
                    Id = 1,
                    MenuName = "Christmas 2021 Menu",
                },
                new Menu
                {
                    Id = 2,
                    MenuName = "Summer 2021 Menu",
                },
                new Menu
                {
                    Id = 3,
                    MenuName = "Winter 2021 Menu",
                }
            );
        }
    }
}
