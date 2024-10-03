using Business.Abstract;
using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _service;
        private readonly IWebHostEnvironment _env;

        public ServiceController(IServiceManager service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto, IFormFile Photo)
        {
            var result = _service.Add(dto, Photo, _env.WebRootPath);

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

            var data = _service.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ServiceUpdateDto dto, IFormFile Photo)
        {
            var result = _service.Update(dto, Photo, _env.WebRootPath);
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
            var result = _service.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
