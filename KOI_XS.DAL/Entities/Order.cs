using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOI_XS.DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

      
        public int CustomerId { get; set; }

        
        public Customer Customer { get; set; }
        public ICollection<OrderKoi> OrderKois { get; set; }
    }
}
