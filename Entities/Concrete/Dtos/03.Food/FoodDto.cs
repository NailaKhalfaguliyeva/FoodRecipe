using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodDto
    {
        public int ID { get; set; }

        public string Photo { get; set; }

        public string FoodCategoryName { get; set; }

        public int FoodCategoryID { get; set; }

        public static List<FoodDto> ToFood(Food food)
        {
            FoodDto dto = new FoodDto()
            {
                ID = food.ID,
                Photo = food.Photo,
                FoodCategoryID = food.FoodCategoryID,
            };
            List<FoodDto> dtoList = new List<FoodDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static Food ToFood(FoodDto Dto)
        {
            Food food = new()
            {
                ID = Dto.ID,
                Photo = Dto.Photo,
                FoodCategoryID = Dto.FoodCategoryID
            };
            return food;
        }


    }
}
