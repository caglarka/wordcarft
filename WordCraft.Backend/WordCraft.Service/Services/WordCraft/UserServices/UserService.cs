using System.Net;
using WordCraft.Core.Models.BaseResponseModels;
using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Data.DbContexts;
using WordCraft.Data.Repositories.WordCraft.UserRepository;
using WordCraft.Data.UnitOfWorks;

namespace WordCraft.Service.Services.WordCraft.UserServices
{
    public class UserService : GenericService<IUserRepository, User>, IUserService
    {
        private readonly IUnitOfWork<WorkCraftContext> _unitOfWorkWc;

        public UserService(IUnitOfWork<WorkCraftContext> unitOfWorkWc) : base(unitOfWorkWc.UserRepository)
        {
            _unitOfWorkWc = unitOfWorkWc;
        }

        public async Task<CustomResponse<List<User>>> GetUsers()
        {
            var entities = await _unitOfWorkWc.UserRepository.GetAllAsync();

            var result = entities.ToList();

            return CustomResponse<List<User>>.Success(HttpStatusCode.OK, result);
        }
    }
}
