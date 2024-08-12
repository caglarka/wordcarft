using System.Linq.Expressions;
using WordCraft.Core.Models.DataModel.BaseDataModel;

namespace WordCraft.Service.Services
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
