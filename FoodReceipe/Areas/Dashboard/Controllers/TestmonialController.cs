using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestmonialController : Controller
    {
        private readonly ITestmonialService _testmonialService;
        private readonly IWebHostEnvironment _env;

        public TestmonialController(ITestmonialService testmonialService, IWebHostEnvironment env)
        {
            _testmonialService = testmonialService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _testmonialService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TestmonialCreateDto dto, IFormFile PhotoUrl)
        {
            var result = _testmonialService.Add(dto, PhotoUrl, _env.WebRootPath);
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
            var data = _testmonialService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(TestmonialUpdateDto dto, IFormFile PhotoUrl)
        {
            var result = _testmonialService.Update(dto, PhotoUrl, _env.WebRootPath);
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
            var result = _testmonialService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
