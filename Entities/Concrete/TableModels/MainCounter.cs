using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class MainCounter:BaseEntity
    {
        public string Icon { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }
    }
}
