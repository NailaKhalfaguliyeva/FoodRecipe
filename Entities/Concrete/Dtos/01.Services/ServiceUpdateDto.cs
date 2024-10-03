using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceUpdateDto
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public static ServiceUpdateDto ToService(Service service)
        {
            ServiceUpdateDto dto = new()
            {
                ID = service.ID,
                Title= service.Title,
                Photo= service.Photo,
                Description = service.Description,
            };
            return dto;
        }
        public static Service ToService(ServiceUpdateDto dto)
        {
            Service service = new()
            {
                ID = dto.ID,
                Title= dto.Title,
                Photo= dto.Photo,
                Description = dto.Description,
            };
            return service;
        }
    }
}
