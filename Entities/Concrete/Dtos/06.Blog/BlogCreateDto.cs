using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; }

        public DateTime Days { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public static BlogCard ToBlog(BlogCreateDto dto)
        {
            BlogCard cards = new()
            {
                Title = dto.Title,
              Days = dto.Days,
              Description = dto.Description,
              Likes = dto.Likes
            };
            return cards;
        }

    }
}
