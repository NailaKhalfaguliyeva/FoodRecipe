using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class AboutRightContentUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

        public static AboutRightContentUpdateDto ToContent(AboutRightContent content)
        {
            AboutRightContentUpdateDto dto = new()
            {
               ID = content.ID,
               Title = content.Title,
               Photo = content.Photo,
               Description = content.Description,
               Progress = content.Progress,
            };
            return dto;
        }
        public static AboutRightContent ToContent(AboutRightContentUpdateDto dto)
        {
            AboutRightContent content = new()
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                Progress = dto.Progress,
            };
            return content;
        }
    }
}
