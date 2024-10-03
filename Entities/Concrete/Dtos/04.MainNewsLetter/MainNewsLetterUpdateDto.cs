using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainNewsLetterUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static MainNewsLetterUpdateDto ToNewsLetter(MainNewsLetter newsLetter)
        {
            MainNewsLetterUpdateDto dto = new()
            {
              ID = newsLetter.ID,
              Title = newsLetter.Title,
              Description = newsLetter.Description,
            };
            return dto;
        }
        public static MainNewsLetter ToNewsLetter(MainNewsLetterUpdateDto dto)
        {
            MainNewsLetter newsletter = new()
            {
              ID= dto.ID,
              Title = dto.Title,
              Description = dto.Description,
            };
            return newsletter;
        }
    }
}
