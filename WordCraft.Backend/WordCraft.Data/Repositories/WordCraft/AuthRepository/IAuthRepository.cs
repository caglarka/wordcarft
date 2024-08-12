using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Data.Repositories.Generics;

namespace WordCraft.Data.Repositories.WordCraft.AuthRepository
{
    public interface IAuthRepository:IGenericRepository<User>
    {
    }
}
