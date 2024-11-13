
using System.ComponentModel.DataAnnotations;

namespace KOI_XS.DAL.Entities
{
    public class Koi
    {
        [Key]
        public int KoiId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên cá Koi")]
        [Display(Name = "Tên")]
        public string? Name { get; set; }
        
        [Display(Name = "Màu")]
        public string? Color { get; set; }

         [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Display(Name = "Giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        public decimal Price { get; set; }

          [Required(ErrorMessage = "Vui lòng nhập giống cá Koi")]
        [Display(Name = "Giống")]
        public string? Breed { get; set; }
        
        [Display(Name = "Hình ảnh")]
        public string? ImageUrl { get; set; }
       
    }
}
