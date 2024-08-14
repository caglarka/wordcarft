using System.Security.Claims;
using WordCraft.Core.Exceptions;
using WordCraft.Core.Keys;
using WordCraft.Core.Models.Dtos.User;

namespace WordCraft.Core.Utilities.Security.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static ClaimModel GetCurrentUser(this ClaimsPrincipal user)
        {
            var result = new ClaimModel();

            if (user?.Identity?.IsAuthenticated != true)
                throw new UnauthorizedException(ErrorMessageKey.Unauthorize);

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedException(ErrorMessageKey.Unauthorize);
            var isInt = int.TryParse(userId, out int userIdVal);
            if (!isInt)
                throw new UnauthorizedException(ErrorMessageKey.Unauthorize);

            var email = user.FindFirst(ClaimTypes.Email)?.Value;

            result.UserId = userIdVal;
            result.Email = email;

            return result;
        }
    }
}
