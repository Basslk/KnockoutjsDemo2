using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutjsDemo2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
    public class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}