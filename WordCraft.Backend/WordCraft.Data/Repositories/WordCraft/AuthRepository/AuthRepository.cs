using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Data.DbContexts;
using WordCraft.Data.Repositories.Generics;

namespace WordCraft.Data.Repositories.WordCraft.AuthRepository
{
    public class AuthRepository : GenericRepository<User, WorkCraftContext>, IAuthRepository
    {
        public AuthRepository(WorkCraftContext workCraftContext) : base(workCraftContext)
        {

        }

        
    }
}
