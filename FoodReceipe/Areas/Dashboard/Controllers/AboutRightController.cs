using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutRightController : Controller
    {
        private readonly IAboutRightContentService _aboutRightContentService;
        private readonly IWebHostEnvironment _env;

        public AboutRightController(IAboutRightContentService aboutRightContentService, IWebHostEnvironment env)
        {
            _aboutRightContentService = aboutRightContentService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _aboutRightContentService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutRightContentCreateDto dto, IFormFile Photo)
        {
            var result = _aboutRightContentService.Add(dto, Photo, _env.WebRootPath);

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

            var data = _aboutRightContentService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(AboutRightContentUpdateDto dto, IFormFile photoUrl)
        {
            var result = _aboutRightContentService.Update(dto, photoUrl, _env.WebRootPath);
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
            var result = _aboutRightContentService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
