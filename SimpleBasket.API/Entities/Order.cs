using System;
using System.Collections.Generic;

namespace SimpleBasket.API.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Freight { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
