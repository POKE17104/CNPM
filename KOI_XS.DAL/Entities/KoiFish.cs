using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOI_XS.DAL.Entities
{
    public class KoiFish
    {
        [Key]
        public int KoiFishId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Navigation Property
        public ICollection<OrderKoi> OrderKois { get; set; }
    }
}
