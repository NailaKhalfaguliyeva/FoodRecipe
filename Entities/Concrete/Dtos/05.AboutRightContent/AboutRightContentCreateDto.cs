using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutRightContentCreateDto
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

        public static AboutRightContent ToContent(AboutRightContentCreateDto dto)
        {
            AboutRightContent content = new()
            {
                Title = dto.Title,
                Photo = dto.Photo,
                Description = dto.Description,
                Progress = dto.Progress,
            };
            return content;
        }
    }
}
