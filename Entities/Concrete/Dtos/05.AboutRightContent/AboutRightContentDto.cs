using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutRightContentDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

        public static List<AboutRightContentDto> ToContent(AboutRightContent content)
        {
            AboutRightContentDto dto = new AboutRightContentDto()
            {
              ID=content.ID,
              Title=content.Title,
              Photo=content.Photo,
              Description=content.Description,
              Progress=content.Progress,
            };
            List<AboutRightContentDto> dtoList = new List<AboutRightContentDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static AboutRightContent ToContent(AboutRightContentDto Dto)
        {
            AboutRightContent content = new()
            {
                ID = Dto.ID,
                Title=Dto.Title,
                Photo=Dto.Photo,
                Description=Dto.Description,
                Progress=Dto.Progress,
            };
            return content;
        }
    }
}
