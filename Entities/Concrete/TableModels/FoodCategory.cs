using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class FoodCategory : BaseEntity
    {
        public FoodCategory()
        {
            Foods = new HashSet<Food>();
        }
        public string Category { get; set; }

        public ICollection<Food> Foods { get; set; }

    }
}
