using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IMainCounterService
    {
        IResullt Add(MainCounterCreateDto dto);

        IResullt Update(MainCounterUpdateDto dto);

        IResullt Delete(int id);

        IDataResult<List<MainCounterDto>> GetAll();

        IDataResult<MainCounter> GetById(int id);
    }
}
