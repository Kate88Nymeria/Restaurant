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
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly RestaurantContext ctx;
        public RepositoryMenuEF(RestaurantContext context)
        {
            ctx = context;
        }

        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;

            ctx.Menus.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool PutDishToMenu(int idMenu, int idDish)
        {
            if (idMenu <= 0 || idDish <= 0)
                return false;

            var menu = ctx.Menus.Find(idMenu);
            var dish = ctx.Dishes.Find(idDish);
            menu.Dishes.Add(dish);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return ctx.Menus.Include(m => m.Dishes).Where(filter);

            return ctx.Menus.Include(m => m.Dishes);
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Menus.Include(m => m.Dishes).FirstOrDefault(m => m.Id == id);
        }

        public bool UpdateItem(Menu item)
        {
            throw new NotImplementedException();
        }

        public bool LeaveDishFromMenu(int idMenu, int idDish)
        {
            if (idMenu <= 0 || idDish <= 0)
                return false;

            var menu = ctx.Menus.Find(idMenu);
            var dish = ctx.Dishes.Find(idDish);
            menu.Dishes.Remove(dish);
            ctx.SaveChanges();
            return true;
        }
    }
}
