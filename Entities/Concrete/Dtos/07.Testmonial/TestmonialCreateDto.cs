using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestmonialCreateDto
    {
        public string Photourl { get; set; }

        public static TestmonialSection ToTestmonial(TestmonialCreateDto dto)
        {
            TestmonialSection section = new()
            {
                PhotoUrl = dto.Photourl,
            };
            return section;
        }
    }
}
