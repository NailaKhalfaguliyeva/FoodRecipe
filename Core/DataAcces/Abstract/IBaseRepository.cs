using Core.Entities.Concrete;
using System.Linq.Expressions;

namespace Core.DataAcces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    }
}
