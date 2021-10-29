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
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.DishName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(d => d.DishType)
                   .IsRequired();

            builder.Property(d => d.Price)
                   .IsRequired();

            builder.HasOne(d => d.Menu)
                   .WithMany(m => m.Dishes);

            builder.Property(d => d.MenuID)
                   .IsRequired();


            builder.HasData(
                new Dish
                {
                    Id = 1,
                    DishName = "Lasagne",
                    DishType = DishType.First,
                    Price = 8.20M,
                    MenuID = 1
                },
                new Dish
                {
                    Id = 2,
                    DishName = "Fish and Chips",
                    DishType = DishType.Second,
                    Price = 6.90M,
                    MenuID = 3
                },
                new Dish
                {
                    Id = 3,
                    DishName = "Cheesecake",
                    DishType = DishType.Dessert,
                    Price = 5.30M,
                    MenuID = 2
                }
            );
        }
    }
}
