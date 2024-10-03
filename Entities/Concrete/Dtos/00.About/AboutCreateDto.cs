using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new()
            {
                Title = dto.Title,
                Description = dto.Description,
            };
            return about;
        }
    }
}
