using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITestmonialService
    {
        IResullt Add(TestmonialCreateDto dto, IFormFile PhotoUrl, string webRootPath);

        IResullt Update(TestmonialUpdateDto dto, IFormFile PhotoUrl, string webRootPath);

        IResullt Delete(int id);

        IDataResult<List<TestmonialDto>> GetAll();

        IDataResult<TestmonialSection> GetById(int id);
    }
}
