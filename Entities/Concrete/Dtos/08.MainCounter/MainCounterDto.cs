using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainCounterDto
    {
        public int ID { get; set; }
        public string Icon { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public static List<MainCounterDto> ToCounter(MainCounter counter)
        {
            MainCounterDto dto = new MainCounterDto()
            {
                ID=counter.ID,
                Icon=counter.Icon,
                Number=counter.Number,
                Description=counter.Description
            };
            List<MainCounterDto> dtoList = new List<MainCounterDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static MainCounter ToCounter(MainCounterDto Dto)
        {
            MainCounter counter = new()
            {
                ID = Dto.ID,
                Icon=Dto.Icon,
                Number=Dto.Number,
                Description=Dto.Description
            };
            return counter;
        }
    }
}
