using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainCreateDto
    {
        public string Photo { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public static Main ToMain(MainCreateDto dto)
        {
            Main main = new()
            {
                Photo = dto.Photo,
                Title = dto.Title,
                Description = dto.Description,
            };
            return main;
        }
    }
}
