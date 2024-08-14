using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WordCraft.Core.Models.DataModel.DataEnum;

namespace WordCraft.Core.Models.DataModel.BaseDataModel
{
    public class BaseEntityModel
    {
        [Required]
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IS_ACTIVE")]
        public ActiveStatus IsActive { get; set; }
    }
}
