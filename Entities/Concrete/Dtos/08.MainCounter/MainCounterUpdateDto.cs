using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class MainCounterUpdateDto
    {
        public int ID { get; set; }
        public string Icon { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }
        public static MainCounterUpdateDto ToCounter(MainCounter counter)
        {
            MainCounterUpdateDto dto = new()
            {
                ID = counter.ID,
                Icon = counter.Icon,
                Number = counter.Number,
                Description = counter.Description
            };
            return dto;
        }
        public static MainCounter ToCounter(MainCounterUpdateDto dto)
        {
            MainCounter counter = new()
            {
               ID=dto.ID,
               Icon = dto.Icon,
               Number = dto.Number,
               Description = dto.Description
            };
            return counter;
        }
    }
}
