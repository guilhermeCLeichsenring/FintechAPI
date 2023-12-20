using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FintechApi.Models
{
    [Table("TAB_BANK")]
    public class BankModel
    {
        [Key]
        [Required]
        [Column("id_bank")]
        public int Id { get; set; }

        [Required]
        [Column("value")]
        public string Value { get; set; }

        [Required]
        [Column("label")]
        public string Label { get; set; }

        public BankModel()
        {
        }
    }
}
