using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.Repositories
{
    public class RepositoryDishEF : IRepositoryDish
    {
        private readonly RestaurantContext ctx;
        public RepositoryDishEF(RestaurantContext context)
        {
            ctx = context;
        }



        public bool AddItem(Dish item)
        {
            if (item == null)
                return false;

            ctx.Dishes.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;

            var dishToDelete = ctx.Dishes.Find(id);
            if (dishToDelete == null)
                return false;

            ctx.Dishes.Remove(dishToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Dish> Fetch(Func<Dish, bool> filter = null)
        {
            if (filter != null)
                return ctx.Dishes.Where(filter);

            return ctx.Dishes;
        }

        public Dish GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Dishes.Find(id);
        }

        public bool UpdateItem(Dish item)
        {
            if (item == null)
                return false;

            ctx.Entry(item).State = EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
