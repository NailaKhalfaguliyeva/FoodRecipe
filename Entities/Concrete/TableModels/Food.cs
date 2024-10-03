using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class Food: BaseEntity
    {
        public string Photo { get; set; }

        public int FoodCategoryID { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
