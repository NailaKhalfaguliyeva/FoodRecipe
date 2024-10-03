using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MainNewsLetterController : Controller
    {
        private readonly IMainNewsLetterService _mainNewsLetterService;

        public MainNewsLetterController(IMainNewsLetterService mainNewsLetterService)
        {
            _mainNewsLetterService = mainNewsLetterService;
        }

        public IActionResult Index()
        {
            var data = _mainNewsLetterService.GetAll().Data;

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MainNewsLetterCreateDto dto)
        {
            var result = _mainNewsLetterService.Add(dto);
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
            var data = _mainNewsLetterService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(MainNewsLetterUpdateDto dto)
        {
            var result = _mainNewsLetterService.Update(dto);

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
            var result = _mainNewsLetterService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
