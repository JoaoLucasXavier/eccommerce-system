using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Notifications;

namespace Entities
{
    public class Base : Notifies
    {
        [Column("id")]
        [Display(Name = "Código")]
        public Guid Id { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
