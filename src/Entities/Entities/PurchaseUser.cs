using System;
using System.Collections.Generic;
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

        [NotMapped]
        [Display(Name = "Quantidade total")]
        public int QuantityProducts { get; set; }

        [NotMapped]
        [Display(Name = "Valor total")]
        public decimal TotalValue { get; set; }

        [NotMapped]
        [Display(Name = "Endereço entrega")]
        public string FullAddress { get; set; }

        [NotMapped]
        public List<Product> ProductList { get; set; }

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
