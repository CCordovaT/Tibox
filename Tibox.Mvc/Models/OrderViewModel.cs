using System.Collections.Generic;
using Tibox.Models;

namespace Tibox.Mvc.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IList<OrderItem> OrderITems { get; set; }
    }
}