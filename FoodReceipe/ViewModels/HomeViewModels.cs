using Entities.Concrete.Dtos;

namespace FoodReceipe.ViewModels
{
    public class HomeViewModels
    {
        public List<AboutDto> AboutsDto { get; set; }

        public List<FoodDto> FoodDtos { get; set; }

        public List<FoodCategoryDto> FoodCategories { get; set; }

        public List<MainDto> MainDtos { get; set; }

        public List<TestmonialDto> testmonialDtos { get; set; }

        public List<MainNewsLetterDto> mainNewsLetterDtos {get;set;}

        public List<MainCounterDto> mainCounterDtos { get; set; }

        public List<AboutRightContentDto> aboutRightContentDtos { get; set; }

        public List<BlogDto> blogDtos { get; set; }

        public List<ServiceDto> ServiceDtos { get; set; }

    }
}
