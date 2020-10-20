using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities
{
    [Table("purchaseUser")]
    public class PurchaseUser : Base
    {
        [Column("purchaseStatus")]
        [Display(Name = "Estado")]
        public PurchaseStatusEmum PurchaseStatus { get; set; }

        [Column("purchaseAmount")]
        [Display(Name = "Quantidade compra")]
        public int PurchaseAmount { get; set; }

        [Column("productId")]
        [Display(Name = "Produto")]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Column("userId")]
        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
