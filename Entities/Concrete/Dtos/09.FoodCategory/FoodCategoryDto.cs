using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryDto
    {
        public int ID { get; set; }
        public string Category { get; set; }

        public static List<FoodCategoryDto> ToCategory(FoodCategory category)
        {
            FoodCategoryDto dto = new FoodCategoryDto()
            {
               ID = category.ID,
               Category = category.Category,
            };
            List<FoodCategoryDto> dtoList = new List<FoodCategoryDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static FoodCategory ToCategory(FoodCategoryDto Dto)
        {
            FoodCategory category = new()
            {
               ID= Dto.ID,
               Category = Dto.Category,
            };
            return category;
        }
    }
}
