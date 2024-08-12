using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WordCraft.Data.Repositories.WordCraft.AuthRepository;
using WordCraft.Data.Repositories.WordCraft.UserRepository;

namespace WordCraft.Data.UnitOfWorks
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        public TContext DbContext { get; set; }

        #region WordCraft Repositories
        public IUserRepository UserRepository { get; set; }
        public IAuthRepository AuthRepository { get; set; }

        #endregion

        Task<int> Complete();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Rollback();
        void TransactionCommit();
    }
}
