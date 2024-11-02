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

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<OrderKoi> OrderKois { get; set; }
    }
}
