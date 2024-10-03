using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainCounterCreateDto
    {
        public string Icon { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public static MainCounter ToCounter(MainCounterCreateDto dto)
        {
            MainCounter counter = new()
            {
                Icon = dto.Icon,
                Number = dto.Number,
                Description = dto.Description
            };
            return counter;
        }
    }
}
