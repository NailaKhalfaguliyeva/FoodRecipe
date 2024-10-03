using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryCreateDto
    {
        public string Category { get; set; }
        public static FoodCategory ToCategory(FoodCategoryCreateDto dto)
        {
            FoodCategory category = new()
            {
               Category = dto.Category,
            };
            return category;
        }
    }
}
