using WordCraft.Core.Models.BaseResponseModels;
using WordCraft.Core.Models.DataModel.WordCraft;

namespace WordCraft.Service.Services.WordCraft.UserServices
{
    public interface IUserService: IGenericService<User>
    {
        Task<CustomResponse<List<User>>> GetUsers();
    }
}
