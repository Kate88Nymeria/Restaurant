using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region DISH

        IEnumerable<Dish> FetchDishes(Func<Dish, bool> filter = null);
        Dish GetDishById(int id);
        ResultBL CreateDish(Dish newDish);
        ResultBL EditDish(Dish modifiedDish);
        ResultBL DeleteDish(int dishId);

        #endregion

        #region MENU

        IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        //Menu GetMenuWithDishes(int id);
        ResultBL CreateMenu(Menu newMenu);

        bool AssignDishToMenu(int idMenu, int idDish);
        bool DecoupleDishToMenu(int idMenu, int idDish);

        #endregion

        #region USER

        User GetUserByEmail(string email);

        #endregion
    }
}
