using System.ComponentModel.DataAnnotations.Schema;
using WordCraft.Core.Models.DataModel.BaseDataModel;

namespace WordCraft.Core.Models.DataModel.WordCraft
{
    [Table("USER")]
    public class User : BaseEntityModel, IEntity
    {
        [Column("NAME")]
        public required string Name { get; set; }

        [Column("SURNAME")]
        public required string Surname { get; set; }

        [Column("EMAIL")]
        public required string Email { get; set; }

        [Column("PASSWORD")]
        public required string Password { get; set; }
    }
}
