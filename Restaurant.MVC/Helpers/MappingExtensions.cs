using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core.Entities;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static IEnumerable<SelectListItem> FromEnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T))).Cast<T>().Select(
                e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() }).ToList();
        }


        #region DISH
        public static DishViewModel ToViewModel(this Dish dish)
        {
            return new DishViewModel
            {
                Id = dish.Id,
                DishName = dish.DishName,
                DishType = dish.DishType,
                Price = dish.Price
            };
        }

        public static IEnumerable<DishViewModel> ToListViewModel(this IEnumerable<Dish> dishes)
        {
            return dishes.Select(d => d.ToViewModel());
        }

        public static Dish ToDish(this DishViewModel dishVM)
        {
            return new Dish
            {
                Id = dishVM.Id,
                DishName = dishVM.DishName,
                DishType = dishVM.DishType,
                Price = dishVM.Price
            };
        }

        #endregion

        #region MENU

        //public static IEnumerable<SelectListItem> FromListToSelectList(this IEnumerable<Menu> menuList)
        //{
        //    return menuList.Select(
        //        e => new SelectListItem() { Text = e.MenuName, Value = e.MenuName }).ToList();
        //}

        public static MenuViewModel ToViewModel(this Menu menu)
        {
            var dishesViewModel = menu.Dishes.ToListViewModel();
            return new MenuViewModel
            {
                Id = menu.Id,
                MenuName = menu.MenuName,
                Dishes = dishesViewModel,
                TotalPrice = dishesViewModel.Sum( d => d.Price)
            };
        }

        public static IEnumerable<MenuViewModel> ToListViewModel(this IEnumerable<Menu> menus)
        {
            return menus.Select(d => d.ToViewModel());
        }

        public static Menu ToMenu(this MenuViewModel menuVM)
        {
            return new Menu
            {
                Id = menuVM.Id,
                MenuName = menuVM.MenuName
            };
        }

        #endregion
    }
}
