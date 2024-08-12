using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WordCraft.Core.Models.ConfigurationModel;
using WordCraft.Core.Models.Dtos.User;
using WordCraft.Core.Utilities.Security.Encryption;
using WordCraft.Core.Utilities.Security.Extensions;

namespace WordCraft.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly JwtTokenConfig _tokenOptions;
        public JwtHelper(IOptions<JwtTokenConfig> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;

        }

        public AccessToken CreateToken(UserClaimDto user)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey!);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token
            };
        }

        private static JwtSecurityToken CreateJwtSecurityToken(JwtTokenConfig tokenOptions, UserClaimDto user, SigningCredentials signingCredentials)
        {
            var expires = DateTime.UtcNow.AddHours(tokenOptions.AccessTokenExpirationHours);
            var jwt = new JwtSecurityToken(issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: expires,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user),
                signingCredentials: signingCredentials);
            return jwt;
        }

        private static IEnumerable<Claim> SetClaims(UserClaimDto user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId);
            claims.AddEmail(user.Email);

            return claims;
        }
    }
}
