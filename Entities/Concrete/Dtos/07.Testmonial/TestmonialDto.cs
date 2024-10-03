using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestmonialDto
    {
        public int ID { get; set; }
        public string PhotoUrl { get; set; }
        public static List<TestmonialDto> ToTestmonial(TestmonialSection section)
        {
            TestmonialDto dto = new TestmonialDto()
            {
               ID=section.ID,
               PhotoUrl=section.PhotoUrl,
            };
            List<TestmonialDto> dtoList = new List<TestmonialDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static TestmonialSection ToTestmonial(TestmonialDto Dto)
        {
            TestmonialSection section = new()
            {
               ID = Dto.ID,
               PhotoUrl=Dto.PhotoUrl,
            };
            return section;
        }
    }
}

