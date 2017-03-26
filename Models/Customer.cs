using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tibox.Models
{
    [Table("Customer")]
    public class Customer
    {        
        [ScaffoldColumn(false)] //para que en las vistas no aparesca este campo
        public int Id { get; set; }                

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(40, ErrorMessage = "Longitud maxima es 40")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(40, ErrorMessage = "Longitud maxima es 40")]
        public string LastName { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [Computed]
        public IEnumerable<Order> Orders { get; set; }

    }
}
