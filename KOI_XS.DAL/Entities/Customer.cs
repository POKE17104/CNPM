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
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên đăng nhập phải có ít nhất 5 ký tự.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
        public string Address { get; set; }

        [StringLength(10, ErrorMessage = "Số điện thoại không được vượt quá 10 ký tự.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }
}
