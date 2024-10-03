using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainDto
    {
        public int ID { get; set; }
        public string Photo { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public static List<MainDto> ToMain(Main main)
        {
            MainDto dto = new MainDto()
            {
                ID = main.ID,
                Photo = main.Photo,
                Description = main.Description,
            };
            List<MainDto> dtoList = new List<MainDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static Main ToMain(MainDto Dto)
        {
            Main main = new()
            {
                ID = Dto.ID,
                Photo = Dto.Photo,
                Description = Dto.Description,
            };
            return main;
        }
    }
}
