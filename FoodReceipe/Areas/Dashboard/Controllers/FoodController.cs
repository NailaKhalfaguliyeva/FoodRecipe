﻿using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IWebHostEnvironment _env;

        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService, IWebHostEnvironment env)
        {
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _foodService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["FoodCategorie"] = _foodCategoryService.GetAll().Data;

            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodCreateDto dto, IFormFile Photo)
        {
            var result = _foodService.Add(dto, Photo, _env.WebRootPath);

            ViewData["FoodCategorie"] = _foodCategoryService.GetAll().Data;

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["FoodCategorie"] = _foodCategoryService.GetAll().Data;

            var data = _foodService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(FoodUpdateDto dto, IFormFile photoUrl)
        {
            var result = _foodService.Update(dto, photoUrl, _env.WebRootPath);
            ViewData["FoodCategorie"] = _foodCategoryService.GetAll().Data;
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _foodService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
