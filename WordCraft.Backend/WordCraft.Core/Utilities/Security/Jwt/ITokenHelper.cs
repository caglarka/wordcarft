using WordCraft.Core.Models.Dtos.User;

namespace WordCraft.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserClaimDto user);
    }
}
