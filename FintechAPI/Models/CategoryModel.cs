using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FintechAPI.Models
{
    [Table("TAB_CATEGORY")]
    public class CategoryModel
    {
        [Key]
        [Column("id_category")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("type")]
        public bool Type { get; set; } // true == Receipt e false == Expend

        [Required]
        [Column("dt_created")]
        public DateTime Created { get; set; }

        
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual UserModel User { get; set; } 

        public CategoryModel()
        {
        }
    }
}
