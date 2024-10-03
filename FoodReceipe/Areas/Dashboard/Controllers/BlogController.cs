﻿using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var data = _blogService.GetAll().Data;


            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogCreateDto dto)
        {
            var result = _blogService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("Description", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _blogService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(BlogUpdateDto dto)
        {
            var result = _blogService.Update(dto);

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
            var result = _blogService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
