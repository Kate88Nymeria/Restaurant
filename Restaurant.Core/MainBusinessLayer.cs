using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Restaurant.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IRepositoryDish repoDish;
        private readonly IRepositoryMenu repoMenu;
        private readonly IRepositoryUser repoUser;

        public MainBusinessLayer(IRepositoryDish rDish, IRepositoryMenu rMenu, IRepositoryUser rUser)
        {
            repoDish = rDish;
            repoMenu = rMenu;
            repoUser = rUser;
        }


        #region DISH

        public ResultBL CreateDish(Dish newDish)
        {
            if (newDish == null)
                return new ResultBL(false, "Invalid Dish data");

            var result = repoDish.AddItem(newDish);

            return new ResultBL(result, result ? "Dish Added" : "Sorry, something wrong!");
        }

        public ResultBL DeleteDish(int dishId)
        {
            if (dishId <= 0)
                return new ResultBL(false, "Invalid Dish data");

            var result = repoDish.DeleteItem(dishId);

            return new ResultBL(result, result ? "Dish Deleted" : "Sorry, something wrong!");
        }

        public ResultBL EditDish(Dish modifiedDish)
        {
            if (modifiedDish == null)
                return new ResultBL(false, "Invalid Dish data");

            var result = repoDish.UpdateItem(modifiedDish);

            return new ResultBL(result, result ? "Dish Updated" : "Sorry, something wrong!");
        }

        public IEnumerable<Dish> FetchDishes(Func<Dish, bool> filter = null)
        {
            return this.repoDish.Fetch(filter);
        }

        public Dish GetDishById(int id)
        {
            if (id <= 0)
                return null;

            return this.repoDish.GetById(id);
        }

        #endregion

        #region MENU

        public ResultBL CreateMenu(Menu newMenu)
        {
            if (newMenu == null)
                return new ResultBL(false, "Invalid Menu data");

            var result = repoMenu.AddItem(newMenu);

            return new ResultBL(result, result ? "Menu Added" : "Sorry, something wrong!");
        }

        public IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null)
        {
            return this.repoMenu.Fetch(filter);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;

            return this.repoMenu.GetById(id);
        }

        public bool AssignDishToMenu(int idMenu, int idDish)
        {
            repoMenu.PutDishToMenu(idMenu, idDish);
            return true;
        }

        public bool DecoupleDishToMenu(int idMenu, int idDish)
        {
            return repoMenu.LeaveDishFromMenu(idMenu, idDish);
        }

        //public Menu GetMenuWithDishes(int id)
        //{
        //    return repoMenu.GetMenu(id);
        //}

        #endregion

        #region USER

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return repoUser.GetByEmail(email);
        }

        #endregion
    }
}
