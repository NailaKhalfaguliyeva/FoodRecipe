using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System.Reflection.Metadata;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResullt Add(AboutCreateDto dto);

        IResullt Update(AboutUpdateDto dto);

        IDataResult<List<AboutDto>> GetAll();

        IDataResult<About> GetById(int id);
    }
}
