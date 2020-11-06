using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Entities
{
    [Table("product")]
    public class Product : Base
    {
        [Column("name")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Description { get; set; }

        [Column("observation")]
        [Display(Name = "Observação")]
        [MaxLength(2000)]
        public string Observation { get; set; }

        [Column("value")]
        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Column("stockQuantity")]
        [Display(Name = "Quantidade estoque")]
        public int StockQuantity { get; set; }

        [Column("state")]
        [Display(Name = "Status")]
        public bool State { get; set; }

        [Column("dateRegister")]
        [Display(Name = "Data cadastro")]
        public DateTime DateRegister { get; set; }

        [Column("changeDate")]
        [Display(Name = "Data alteração")]
        public DateTime ChangeDate { get; set; }

        [Column("userId")]
        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [NotMapped]
        public Guid ProductCartId { get; set; }

        [NotMapped]
        public int PurchaseQuantity { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [Column("url")]
        public string Url { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
