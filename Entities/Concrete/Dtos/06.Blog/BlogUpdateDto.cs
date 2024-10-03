using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BlogUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime Days { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }


        public static BlogUpdateDto ToBlog(BlogCard cards)
        {
            BlogUpdateDto dto = new()
            {
              ID = cards.ID,
              Title = cards.Title,
              Days = cards.Days,
              Description = cards.Description,
              Likes = cards.Likes
            };
            return dto;
        }
        public static BlogCard ToBlog(BlogUpdateDto dto)
        {
            BlogCard cards = new()
            {
               ID=dto.ID,
               Title = dto.Title,
               Days = dto.Days,
               Description = dto.Description,
               Likes = dto.Likes
            };
            return cards;
        }
    }
}
