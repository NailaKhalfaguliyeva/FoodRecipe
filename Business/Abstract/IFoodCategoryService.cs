using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFoodCategoryService
    {
        IResullt Add(FoodCategoryCreateDto dto);

        IResullt Update(FoodCategoryUpdateDto dto);

        IResullt Delete(int id);

        IDataResult<List<FoodCategoryDto>> GetAll();

        IDataResult<FoodCategory> GetById(int id);
    }
}
