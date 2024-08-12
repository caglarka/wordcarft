using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WordCraft.Core.Models.DataModel.BaseDataModel;
using WordCraft.Core.Models.DataModel.DataEnum;
using WordCraft.Core.Models.PagedModel;
using WordCraft.Data.Utilities.Helper;

namespace WordCraft.Data.Repositories.Generics
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class, IEntity where TContext : DbContext
    {
        protected readonly TContext _context;

        protected GenericRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<PagedResultModel<TEntity>> GetAllPagedAsync(int page, int pageSize)
        {
            return await _context.Set<TEntity>().GetPaged(page, pageSize);
        }

        public async Task<PagedResultModel<TEntity>> GetAllPagedAsync(int page,
            int pageSize,
            Expression<Func<TEntity, object>> orderBy,
            bool ascending = true)
        {
            return await _context.Set<TEntity>().GetPaged(page, pageSize, orderBy, ascending);
        }

        public async Task<PagedResultModel<TEntity>> GetPagedWithQuery(List<FilteringModel> predicate, int page,
            int pageSize,
            List<SortingModel> orderBy,
            List<Expression<Func<TEntity, object>>> orderByDesc
        )
        {
            return await _context.Set<TEntity>().GetPagedWithQuery(predicate, page, pageSize, orderBy, orderByDesc);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false)
        {
            if (tracked)
                return await _context.Set<TEntity>().Where(predicate).ToListAsync();
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<PagedResultModel<TEntity>> FindPagedAsync(int page, int pageSize,
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).GetPaged(page, pageSize);
        }

        public async Task<PagedResultModel<TEntity>> FindPagedAsync(int page,
            int pageSize,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> orderBy,
            bool ascending = true)
        {
            return await _context.Set<TEntity>().Where(predicate).GetPaged(page, pageSize, orderBy, ascending);
        }

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false)
        {
            if (tracked)
                return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public Task<int> ExecuteSqlAsync(string query)
        {
            return _context.Database.ExecuteSqlRawAsync(query);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Attach(entities);
            _context.Entry(entities).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SoftRemove(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsActive");

            var propertyValue = (int?)property?.GetValue(entity);

            if (property != null && propertyValue.HasValue)
            {
                _context.Entry(entity).State = EntityState.Modified;
                property.SetValue(entity, (int)ActiveStatus.InActive);
            }
        }

        public void SoftRemoveRecover(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsActive");

            var propertyValue = (int?)property?.GetValue(entity);

            if (property != null && propertyValue.HasValue)
            {
                _context.Entry(entity).State = EntityState.Modified;
                property.SetValue(entity, (int)ActiveStatus.Active);
            }
        }

        public void SoftRemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var property = entity.GetType().GetProperty("IsActive");

                var propertyValue = (int?)property?.GetValue(entity);

                if (property != null && propertyValue.HasValue)
                {
                    property.SetValue(entity, (int)ActiveStatus.InActive);
                }
            }
        }

        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public List<EntityEntry>? ChangeTrackerState(EntityState entityState)
        {
            return _context.ChangeTracker.Entries()?.Where(x => x.State == entityState).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
