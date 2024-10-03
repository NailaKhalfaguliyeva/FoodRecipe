using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestmonialUpdateDto
    {

        public int ID { get; set; }
        public string PhotoUrl { get; set; }

        public static TestmonialUpdateDto ToTestmonial(TestmonialSection section)
        {
            TestmonialUpdateDto dto = new()
            {
                ID = section.ID,
                PhotoUrl = section.PhotoUrl,
            };
            return dto;
        }
        public static TestmonialSection ToTestmonial(TestmonialUpdateDto dto)
        {
            TestmonialSection section = new()
            {
               ID= dto.ID,
               PhotoUrl = dto.PhotoUrl,
            };
            return section;
        }
    }
}
