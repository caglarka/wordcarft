namespace WordCraft.Core.Models.ConfigurationModel
{
    public class JwtTokenConfig
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public string? SecurityKey { get; set; }
        public int AccessTokenExpirationHours { get; set; }
    }
}
