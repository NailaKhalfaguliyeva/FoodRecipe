using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainNewsLetterCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public static MainNewsLetter ToNewsLetter(MainNewsLetterCreateDto dto)
        {
            MainNewsLetter main = new()
            {
               Title = dto.Title,
               Description = dto.Description,
            };
            return main;
        }

    }
}
