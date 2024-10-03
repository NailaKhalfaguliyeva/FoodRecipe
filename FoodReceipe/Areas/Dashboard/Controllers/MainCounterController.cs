using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MainCounterController : Controller
    {
        private readonly IMainCounterService _mainCounterService;

        public MainCounterController(IMainCounterService mainCounterService)
        {
            _mainCounterService = mainCounterService;
        }

        public IActionResult Index()
        {
            var data = _mainCounterService.GetAll().Data;

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MainCounterCreateDto dto)
        {
            var result = _mainCounterService.Add(dto);
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
            var data = _mainCounterService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(MainCounterUpdateDto dto)
        {
            var result = _mainCounterService.Update(dto);

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
            var result = _mainCounterService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
