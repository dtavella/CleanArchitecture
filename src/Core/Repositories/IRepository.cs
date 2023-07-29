using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IRepository<TE, TI> where TE : EntityBase<TI>
    {
        Task<IList<TE>> GetAll();
        Task<TE> Get(long id);
        void Update(TE entity);
        Task<TE> Add(TE entity);
        void Delete(TE entity);
        Task<bool> Any(Expression<Func<TE, bool>> predicate);

        Task<TProyected> GetProyected<TProyected>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TProyected>> proyection); 
        Task<IEnumerable<TProyected>> GetProyectedMany<TProyected>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TProyected>> proyection); 
    }
}
