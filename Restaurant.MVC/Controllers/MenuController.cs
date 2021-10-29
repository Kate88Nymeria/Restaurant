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
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public MenuController(IMainBusinessLayer bl)
        {
            mainBL = bl;
        }

        public IActionResult Index()
        {
            var result = mainBL.FetchMenus();
            var resultMapping = result.ToListViewModel();

            return View(resultMapping);
        }

        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }
        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            Menu newMenu = model.ToMenu();
            var result = mainBL.CreateMenu(newMenu);

            if (!result.Success)
                return View("ExceptionError", result);

            return RedirectToAction(nameof(Index));
        }
    }
}
