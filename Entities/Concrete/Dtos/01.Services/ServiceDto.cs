using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceDto
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static List<ServiceDto> ToService(Service service)
        {
            ServiceDto dto = new ServiceDto()
            {
                ID = service.ID,
                Description = service.Description,
            };
            List<ServiceDto> dtoList = new List<ServiceDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static Service ToService(ServiceDto Dto)
        {
            Service service = new()
            {
                ID = Dto.ID,
                Description = Dto.Description,
            };
            return service;
        }
    }
}
