using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainUpdateDto
    {
        public int ID { get; set; }
        public string Photo { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public static MainUpdateDto ToMain(Main main)
        {
            MainUpdateDto dto = new()
            {
                ID = main.ID,
                Photo = main.Photo,
                Title = main.Title,
                Description = main.Description,
            };
            return dto;
        }
        public static Main ToMain(MainUpdateDto dto)
        {
            Main main = new()
            {
                ID = dto.ID,
                Photo = dto.Photo,
                Title = dto.Title,
                Description = dto.Description,
            };
            return main;
        }
    }
}
