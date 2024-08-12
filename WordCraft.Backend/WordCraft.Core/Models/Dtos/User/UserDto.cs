using WordCraft.Core.Models.DataModel.DataEnum;

namespace WordCraft.Core.Models.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public ActiveStatus IsActive { get; set; }
    }
}
