using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("cpf")]
        [Display(Name = "CPF")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("age")]
        [Display(Name = "Idade")]
        public int Age { get; set; }

        [Column("name")]
        [Display(Name = "Nome")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("postalCode")]
        [Display(Name = "CEP")]
        [MaxLength(8)]
        public string PostalCode { get; set; }

        [Column("address")]
        [Display(Name = "Endereço")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Column("complement")]
        [Display(Name = "Complemento")]
        [MaxLength(100)]
        public string Complement { get; set; }

        [Column("cellPhone")]
        [Display(Name = "Celular")]
        [MaxLength(20)]
        public string CellPhone { get; set; }

        [Column("phone")]
        [Display(Name = "Telefone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column("state")]
        [Display(Name = "Estado")]
        public bool State { get; set; }

        [Column("type")]
        [Display(Name = "Tipo usuário")]
        public UserTypeEnum Type { get; set; }
    }
}
