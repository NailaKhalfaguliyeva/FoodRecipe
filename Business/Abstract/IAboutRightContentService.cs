using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IAboutRightContentService
    {
        IResullt Add(AboutRightContentCreateDto dto, IFormFile Photo, string webRootPath);

        IResullt Update(AboutRightContentUpdateDto dto, IFormFile Photo, string webRootPath);

        IResullt Delete(int id);

        IDataResult<List<AboutRightContentDto>> GetAll();

        IDataResult<AboutRightContent> GetById(int id);
    }
}
