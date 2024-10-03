
using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Bussines.Abstract
{
    public interface IServiceManager
    {
        IResullt Add(ServiceCreateDto dto, IFormFile Photo, string webRootPath);

        IResullt Update(ServiceUpdateDto dto, IFormFile Photo, string webRootPath);

        IResullt Delete(int id);

        IDataResult<List<ServiceDto>> GetAll();

        IDataResult<Service> GetById(int id);

    }
}
