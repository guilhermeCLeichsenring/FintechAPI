using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FintechApi.Models;

namespace FintechAPI.Models
{
    [Table("TAB_TRANSACTION")]
    public class TransactionModel
    {
        [Key]
        [Required]
        [Column("id_transaction")]
        public int Id { get; set; }

        [Required]
        [Column("value")]
        public double Value { get; set; }

        [Required]
        [Column("description")]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("type")]
        public bool Type { get; set; } // true == Receipt e false == Expend

        [Required]
        [Column("dt_created")]
        public DateTime Created { get; set; }

        [ForeignKey(nameof(User))]
        [Column("id_user")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual UserModel User { get; set; }

        [ForeignKey(nameof(Category))]
        [Column("id_category")]
        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }

        [ForeignKey(nameof(Bank))]
        [Column("id_bank")]
        public int BankId { get; set; }

        public BankModel Bank { get; set; }

        public TransactionModel()
        {
        }
    }


}
