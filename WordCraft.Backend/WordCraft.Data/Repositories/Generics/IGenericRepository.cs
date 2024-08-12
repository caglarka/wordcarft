using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WordCraft.Core.Models.DataModel.BaseDataModel;
using WordCraft.Core.Models.PagedModel;

namespace WordCraft.Data.Repositories.Generics
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedResultModel<TEntity>> GetAllPagedAsync(int page, int pageSize);
        Task<PagedResultModel<TEntity>> GetAllPagedAsync(int page, int pageSize, Expression<Func<TEntity, object>> orderBy, bool ascending = true);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
        Task<PagedResultModel<TEntity>> FindPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>> predicate);
        Task<PagedResultModel<TEntity>> FindPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderBy, bool ascending = true);
        Task<PagedResultModel<TEntity>> GetPagedWithQuery(List<FilteringModel> predicate, int page,
                                                                 int pageSize,
        List<SortingModel> orderBy, List<Expression<Func<TEntity, object>>> orderByDesc
                                                                 );
        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> ExecuteSqlAsync(string query);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void SoftRemove(TEntity entity);
        void SoftRemoveRecover(TEntity entity);
        void SoftRemoveRange(IEnumerable<TEntity> entities);

        void ChangeTrackerClear();
        List<EntityEntry>? ChangeTrackerState(EntityState entityState);
        Task<bool> SaveChangesAsync();
    }
}
