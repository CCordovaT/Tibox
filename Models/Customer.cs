using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Tibox.Models
{
    [Table("Customer")]
    public class Customer
    {        
        public int Id { get; set; }                
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [Computed]
        public IEnumerable<Order> Orders { get; set; }

    }
}
