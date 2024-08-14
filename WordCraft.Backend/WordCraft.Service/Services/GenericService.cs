using System.Linq.Expressions;
using WordCraft.Core.Models.DataModel.BaseDataModel;
using WordCraft.Data.Repositories.Generics;

namespace WordCraft.Service.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TEntity> where TEntity : class, IEntity
                                                                                 where TRepository : IGenericRepository<TEntity>
    {
        private readonly IGenericRepository<TEntity> _Repository;

        public GenericService(TRepository repository)
        {
            _Repository = repository;
        }

        public async virtual Task<TEntity?> GetByIdAsync(int id) => await _Repository.GetByIdAsync(id);

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync() => await _Repository.GetAllAsync();

        public async virtual Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false)
            => await _Repository.FirstOrDefaultAsync(predicate, tracked);

        public async virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false)
            => await _Repository.FindAsync(predicate, tracked);

        public async virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await _Repository.AnyAsync(predicate);
    }
}
