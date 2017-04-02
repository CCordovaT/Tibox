using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tibox.Models;

namespace Tibox.Mvc.Models
{
    public class OrderViewModel
    {

        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}