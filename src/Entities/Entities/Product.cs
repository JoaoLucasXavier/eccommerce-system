using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("product")]
    public class Product : Base
    {
        [Column("value")]
        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Column("state")]
        [Display(Name = "Status")]
        public bool State { get; set; }
    }
}
