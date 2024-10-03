using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCreateDto
    {
        public string Photo { get; set; }

        public int FoodCategoryID { get; set; }

        public static Food ToFood(FoodCreateDto dto)
        {
            Food food = new()
            {
                Photo = dto.Photo,
                FoodCategoryID = dto.FoodCategoryID,
            };
            return food;
        }
    }
}
