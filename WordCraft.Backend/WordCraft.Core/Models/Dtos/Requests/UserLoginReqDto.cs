namespace WordCraft.Core.Models.Dtos.Requests
{
    public class UserLoginReqDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
