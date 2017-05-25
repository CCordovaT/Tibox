using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Tibox.Models
{
    [Table("Supplier")]
    public class Supplier
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(80, ErrorMessage = "The max length is 80 chars.")]
        public string CompanyName { get; set; }
        [StringLength(100, ErrorMessage = "The max length is 100 chars.")]
        public string ContactName { get; set; }
        [StringLength(80, ErrorMessage = "The max length is 80 chars.")]
        public string ContactTitle { get; set; }
        [StringLength(80, ErrorMessage = "The max length is 80 chars.")]
        public string City { get; set; }
        [StringLength(80, ErrorMessage = "The max length is 80 chars.")]
        public string Country { get; set; }
        [StringLength(60, ErrorMessage = "The max length is 60 chars.")]
        public string Phone { get; set; }
        [StringLength(60, ErrorMessage = "The max length is 60 chars.")]
        public string Fax { get; set; }
    }
}
