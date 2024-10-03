using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResullt Add(BlogCreateDto dto);

        IResullt Update(BlogUpdateDto dto);

        IResullt Delete(int id);

        IDataResult<List<BlogDto>> GetAll();

        IDataResult<BlogCard> GetById(int id);
    }
}
