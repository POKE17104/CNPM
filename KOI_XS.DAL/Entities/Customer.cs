using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOI_XS.DAL.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }
}
