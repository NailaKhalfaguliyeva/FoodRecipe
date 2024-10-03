using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BlogDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime Days { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public static List<BlogDto> ToBlog(BlogCard cards)
        {
            BlogDto dto = new BlogDto()
            {
                ID=cards.ID,
                Title = cards.Title,
                Days=cards.Days,
                Description=cards.Description,
                Likes=cards.Likes
            };
            List<BlogDto> dtoList = new List<BlogDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static BlogCard ToBlog(BlogDto Dto)
        {
            BlogCard cards = new()
            {
                ID = Dto.ID,
                Title = Dto.Title,
                Days=Dto.Days,
                Description=Dto.Description,
                Likes=Dto.Likes
            };
            return cards;
        }
    }
}
