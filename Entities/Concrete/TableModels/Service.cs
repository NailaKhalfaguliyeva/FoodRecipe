using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class Service:BaseEntity
    {
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
