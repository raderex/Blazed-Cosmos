using System;
using System.Collections.Generic;

namespace BlazedCosmos.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public List<CartItem> CartItems { get; internal set; }
    }
}
