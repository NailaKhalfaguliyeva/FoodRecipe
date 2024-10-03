using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IMainService
    {
        IResullt Add(MainCreateDto dto, IFormFile Photo, string webRootPath);

        IResullt Update(MainUpdateDto dto, IFormFile Photo, string webRootPath);

        IResullt Delete(int id);

        IDataResult<List<MainDto>> GetAll();

        IDataResult<Main> GetById(int id);
    }
}
