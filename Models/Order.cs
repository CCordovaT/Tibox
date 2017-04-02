
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
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }        
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        [Computed]           
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
