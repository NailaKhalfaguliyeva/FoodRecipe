using Core.Entities.Concrete;

namespace Entities.Concrete.TableModels
{
    public class AboutRightContent:BaseEntity
    {
        public string Title { get; set; } 
        public string Photo { get; set; } 
        public string Description { get; set; } 
        public int Progress { get; set; } 
    }
}
