using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static AboutUpdateDto ToAbout(About about)
        {
            AboutUpdateDto dto = new()
            {
                ID = about.ID,
                Title=about.Title,
                Description = about.Description,
            };
            return dto;
        }
        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new()
            {
                ID = dto.ID,
                Title=dto.Title,
                Description = dto.Description,
            };
            return about;
        }

    }
}
