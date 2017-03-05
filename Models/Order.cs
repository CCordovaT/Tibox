
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tibox.Models
{
    [Table("[Order]")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }        
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        [Computed]           
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
