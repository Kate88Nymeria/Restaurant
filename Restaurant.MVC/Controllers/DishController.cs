using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.MVC.Helpers;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Controllers
{
    public class DishController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public DishController(IMainBusinessLayer bl)
        {
            mainBL = bl;
        }

        public IActionResult Index()
        {
            var result = mainBL.FetchDishes();
            var resultMapping = result.ToListViewModel();

            return View(resultMapping);
        }

        public IActionResult Create()
        {
            LoadViewBag();
            return View(new DishViewModel());
        }
        [HttpPost]
        public IActionResult Create(DishViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            Dish newDish = model.ToDish();
            var result = mainBL.CreateDish(newDish);

            if (!result.Success)
                return View("ExceptionError", result);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");

            var dishToEdit = mainBL.GetDishById(id);
            if (dishToEdit == null)
                return View("NotFound");

            var dishVM = dishToEdit.ToViewModel();
            LoadViewBag();
            return View(dishVM);
        }

        [HttpPost]
        public IActionResult Edit(DishViewModel dvm)
        {
            if (!ModelState.IsValid)
                return View(dvm);

            if (dvm == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            var dishToEdit = dvm.ToDish();
            var result = mainBL.EditDish(dishToEdit);

            if (!result.Success)
                return View("ExceptionError", result);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("NotFound");

            var dishToDelete = mainBL.GetDishById(id);
            if (dishToDelete == null)
                return View("NotFound");

            var dishVm = dishToDelete.ToViewModel();

            return View(dishVm);
        }
        [HttpPost]
        public IActionResult DeleteDish(int id)
        {
            if (id <= 0)
                return View("Exception Error", new ResultBL(false, "Something wrong!"));

            var result = mainBL.DeleteDish(id);
            if (!result.Success)
                return View("Exception Error", result);

            return RedirectToAction(nameof(Index));
        }



        private void LoadViewBag()
        {
            ViewBag.Categories = MappingExtensions.FromEnumToSelectList<DishType>();
            var menuList = mainBL.FetchMenus();

            ViewBag.Menus = menuList.FromListToSelectList();
        }
    }
}
