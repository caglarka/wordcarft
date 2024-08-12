using WordCraft.Core.Models.BaseResponseModels;
using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Core.Models.Dtos.Requests;
using WordCraft.Core.Models.Dtos.Responses.User;

namespace WordCraft.Service.Services.WordCraft.AuthServices
{
    public interface IAuthService : IGenericService<User>
    {
        Task<CustomResponse<UserLoginResDto>> Login(UserLoginReqDto model);
    }
}
