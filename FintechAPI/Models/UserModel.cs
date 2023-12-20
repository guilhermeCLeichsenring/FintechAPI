using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FintechAPI.Models
{
    [Table("TAB_USER")]
    public class UserModel
    {
        [Key]
        [Required]
        [Column("id_user")]
        public int Id { get; set; }

        [Required]
        [Column("name")]    
        public string Name { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(16)]
        public string Password { get; set; }

        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("dt_created")]
        public DateTime Created { get; set; }
        
        public virtual List<CategoryModel>? CategoryModels { get; set; } = new List<CategoryModel>();

        public virtual List<TransactionModel>? Transactions { get; set; } = new List<TransactionModel>();


        public UserModel()
        {
        }
    }
}
