using System;
using System.Collections.Generic;

namespace KOI.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
