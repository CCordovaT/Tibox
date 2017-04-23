using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tibox.Models
{
    [Table("[Order]")]
    public class Order
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime OrderDate { get; set; }                
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        [Computed]
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
