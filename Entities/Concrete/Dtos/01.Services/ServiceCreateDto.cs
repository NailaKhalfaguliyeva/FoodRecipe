using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceCreateDto
    {
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static Service ToService(ServiceCreateDto dto)
        {
            Service service = new()
            {
                Photo = dto.Photo,
                Title = dto.Title,
                Description = dto.Description,
            };
            return service;
        }
    }
}
