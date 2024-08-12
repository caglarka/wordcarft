using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WordCraft.Data.Repositories.WordCraft.AuthRepository;
using WordCraft.Data.Repositories.WordCraft.UserRepository;

namespace WordCraft.Data.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        public UnitOfWork(
            T DbContext,
            IUserRepository userRepository,
            IAuthRepository authRepository)
        {
            this.DbContext = DbContext;
            UserRepository = userRepository;
            AuthRepository = authRepository;
        }

        public T DbContext { get; set; }

        private IDbContextTransaction? _transaction;

        #region WordCraft Repositories

        public IUserRepository UserRepository { get; set; }
        public IAuthRepository AuthRepository { get; set; }

        #endregion

        public async Task<int> Complete()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void TransactionCommit()
        {
            _transaction?.Commit();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await DbContext.Database.BeginTransactionAsync();
            return _transaction;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
        }
    }
}
