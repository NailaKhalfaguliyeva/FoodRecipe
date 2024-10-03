using Business.Abstract;
using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MainController : Controller
    {
        private readonly IMainService _mainService;
        private readonly IWebHostEnvironment _env;

        public MainController(IMainService mainService, IWebHostEnvironment env)
        {
            _mainService = mainService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _mainService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MainCreateDto dto, IFormFile Photo)
        {
            var result = _mainService.Add(dto, Photo, _env.WebRootPath);

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

            var data = _mainService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(MainUpdateDto dto, IFormFile Photo)
        {
            var result = _mainService.Update(dto, Photo, _env.WebRootPath);
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
            var result = _mainService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
