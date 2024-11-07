
using System.ComponentModel.DataAnnotations;

namespace KOI_XS.DAL.Entities
{
    public class Koi
    {
        [Key]
        public int KoiId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string? Breed { get; set; }
        public string? ImageUrl { get; set; }
       
    }
}
