using AutoMapper;
using System.Net;
using WordCraft.Core.Keys;
using WordCraft.Core.Models.BaseResponseModels;
using WordCraft.Core.Models.DataModel.DataEnum;
using WordCraft.Core.Models.DataModel.WordCraft;
using WordCraft.Core.Models.Dtos.Requests;
using WordCraft.Core.Models.Dtos.Responses.User;
using WordCraft.Core.Models.Dtos.User;
using WordCraft.Core.Utilities.Security.Jwt;
using WordCraft.Data.DbContexts;
using WordCraft.Data.Repositories.WordCraft.AuthRepository;
using WordCraft.Data.UnitOfWorks;

namespace WordCraft.Service.Services.WordCraft.AuthServices
{
    public class AuthService : GenericService<IAuthRepository, User>, IAuthService
    {
        private readonly IUnitOfWork<WorkCraftContext> _unitOfWorkWc;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;


        public AuthService(IUnitOfWork<WorkCraftContext> unitOfWorkWc,
                           ITokenHelper tokenHelper,
                           IMapper mapper) : base(unitOfWorkWc.AuthRepository)
        {
            _unitOfWorkWc = unitOfWorkWc;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<CustomResponse<UserLoginResDto>> Login(UserLoginReqDto model)
        {
            var userEntity = await _unitOfWorkWc.UserRepository.FirstOrDefaultAsync(i =>
                i.Email.Equals(model.Email) &&
                i.Password.Equals(model.Password) &&
                i.IsActive == ActiveStatus.Active);

            if (userEntity == null)
                return CustomResponse<UserLoginResDto>.Fail(HttpStatusCode.NotFound, ErrorMessageKey.UserNotFound);


            var userClaim = _mapper.Map<UserClaimDto>(userEntity);
            var userDto = _mapper.Map<UserDto>(userEntity);
            var accessToken = _tokenHelper.CreateToken(userClaim);

            var response = new UserLoginResDto() { AccessToken = accessToken, User = userDto };

            return CustomResponse<UserLoginResDto>.Success(HttpStatusCode.OK, response);
        }

    }
}
