using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IResullt Add(FoodCreateDto dto, IFormFile Photo, string webRootPath);

        IResullt Update(FoodUpdateDto dto, IFormFile Photo, string webRootPath);
        
        IResullt Delete(int id);

        IDataResult<List<FoodDto>> GetAll();

        IDataResult<Food> GetById(int id);
    }
}
