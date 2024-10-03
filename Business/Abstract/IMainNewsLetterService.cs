using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IMainNewsLetterService
    {
        IResullt Add(MainNewsLetterCreateDto dto);

        IResullt Update(MainNewsLetterUpdateDto dto);

        IResullt Delete(int id);

        IDataResult<List<MainNewsLetterDto>> GetAll();

        IDataResult<MainNewsLetter> GetById(int id);
    }
}
