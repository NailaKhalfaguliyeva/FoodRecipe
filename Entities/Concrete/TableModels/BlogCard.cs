using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class BlogCard:BaseEntity
    {
        public string Title { get; set; }

        public DateTime Days { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }
    }
}
