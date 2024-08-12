using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Data.DbContexts;
using WordCraft.Data.Repositories.Generics;

namespace WordCraft.Data.Repositories.WordCraft.UserRepository
{
    public class UserRepository : GenericRepository<User, WorkCraftContext>, IUserRepository
    {
        public UserRepository(WorkCraftContext context) : base(context)
        {
        }
    }
}
