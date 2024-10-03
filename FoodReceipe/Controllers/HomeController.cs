using Business.Abstract;
using Bussines.Abstract;
using FoodReceipe.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodReceipe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IMainNewsLetterService _mainNewsLetterService;
        private readonly IAboutRightContentService _aboutRightContentService;
        private readonly ITestmonialService _testmonialService;
        private readonly IBlogService _blogService;
        private readonly IMainService _mainService;
        private readonly IServiceManager _service;
        private readonly IMainCounterService _counterService;

        public HomeController(
            IAboutService aboutService,
            IFoodService foodService,
            IMainService mainService,
            IServiceManager service,
            IFoodCategoryService foodCategoryService,
            IMainNewsLetterService mainNewsLetterService,
            IAboutRightContentService aboutRightContentService,
            IBlogService blogService,
            ITestmonialService testmonialService,
            IMainCounterService counterService)

        {
            _aboutService = aboutService;
            _foodService = foodService;
            _mainService = mainService;
            _service = service;
            _foodCategoryService = foodCategoryService;
            _mainNewsLetterService = mainNewsLetterService;
            _aboutRightContentService = aboutRightContentService;
            _blogService = blogService;
            _testmonialService = testmonialService;
            _counterService = counterService;
        }

        public IActionResult Index()
        {
            var viewModel = CreateHomeViewModel();
            return View(viewModel);
        }

        private HomeViewModels CreateHomeViewModel()
        {
            return new HomeViewModels
            {

                AboutsDto = _aboutService.GetAll().Data,
                FoodDtos = _foodService.GetAll().Data,
                MainDtos = _mainService.GetAll().Data,
                ServiceDtos = _service.GetAll().Data,
                FoodCategories= _foodCategoryService.GetAll().Data,
                mainNewsLetterDtos= _mainNewsLetterService.GetAll().Data,
                aboutRightContentDtos=_aboutRightContentService.GetAll().Data,
                blogDtos= _blogService.GetAll().Data,
                testmonialDtos= _testmonialService.GetAll().Data,
                mainCounterDtos=_counterService.GetAll().Data,

            };
        }
    }
}
