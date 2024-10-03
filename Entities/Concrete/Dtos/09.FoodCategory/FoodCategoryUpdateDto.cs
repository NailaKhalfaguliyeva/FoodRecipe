using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryUpdateDto
    {
        public int ID { get; set; }
        public string Category { get; set; }

        public static FoodCategoryUpdateDto ToCategory(FoodCategory category)
        {
            FoodCategoryUpdateDto dto = new()
            {
                ID = category.ID,
                Category = category.Category,
            };
            return dto;
        }
        public static FoodCategory ToCategory(FoodCategoryUpdateDto dto)
        {
            FoodCategory category = new()
            {
               ID= dto.ID,
               Category = dto.Category,
            };
            return category;
        }
    }
}
