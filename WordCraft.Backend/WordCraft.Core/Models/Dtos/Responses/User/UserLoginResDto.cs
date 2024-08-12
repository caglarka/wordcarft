using WordCraft.Core.Models.Dtos.User;
using WordCraft.Core.Utilities.Security.Jwt;

namespace WordCraft.Core.Models.Dtos.Responses.User
{
    public class UserLoginResDto
    {
        public AccessToken? AccessToken { get; set; }
        public UserDto? User { get; set; }
    }
}
