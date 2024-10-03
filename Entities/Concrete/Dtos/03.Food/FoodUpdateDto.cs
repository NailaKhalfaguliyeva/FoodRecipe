using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodUpdateDto
    {
        public int ID { get; set; }

        public string Photo { get; set; }
        public int FoodCategoryID { get; set; }

        public static FoodUpdateDto ToFood(Food food)
        {
            FoodUpdateDto dto = new()
            {
               ID = food.ID,
                Photo = food.Photo,
                FoodCategoryID = food.FoodCategoryID,
            };
            return dto;
        }
        public static Food ToFood(FoodUpdateDto dto)
        {
            Food food = new()
            {
                ID=dto.ID,
                Photo = dto.Photo,
                FoodCategoryID = dto.FoodCategoryID,
            };
            return food;
        }
    }
}
