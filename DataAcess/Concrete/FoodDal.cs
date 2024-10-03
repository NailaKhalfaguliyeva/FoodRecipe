using Core.DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAcess.Concrete
{
    public class FoodDal : BaseRepository<Food, AppDbcontext>, IFoodDal
    {
        private readonly AppDbcontext _context;

        public FoodDal(AppDbcontext context)
        {
            _context = context;
        }
        public List<FoodDto> GetFoodWithFoodCategories()
        {
            var result = from food in _context.Foods
                         where food.Deleted == 0
                         join foodcategory in _context.FoodCategories
                         on food.FoodCategoryID equals foodcategory.ID
                         where foodcategory.Deleted == 0
                         select new FoodDto
                         {
                             ID = food.ID,
                             Photo=food.Photo,
                             FoodCategoryName=foodcategory.Category,
                             FoodCategoryID=food.FoodCategoryID,
                         };
            return result.ToList();
        }
    }

   
}
