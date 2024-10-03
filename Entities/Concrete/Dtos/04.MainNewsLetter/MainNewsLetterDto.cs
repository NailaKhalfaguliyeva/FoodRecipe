using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainNewsLetterDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }


        public static List<MainNewsLetterDto> ToNewsLetter(MainNewsLetter newsLetter)
        {
            MainNewsLetterDto dto = new MainNewsLetterDto()
            {
              ID=newsLetter.ID,
              Title = newsLetter.Title,
              Description = newsLetter.Description,
            };
            List<MainNewsLetterDto> dtoList = new List<MainNewsLetterDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static MainNewsLetter ToNewsLetter(MainNewsLetterDto Dto)
        {
            MainNewsLetter newsletter = new()
            {
               ID = Dto.ID,
               Title=Dto.Title,
               Description=Dto.Description,
            };
            return newsletter;
        }
    }
}
