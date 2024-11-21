using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KOI_XS.DAL.Entities;
using KOI_XS.DAL; // Đảm bảo bạn sử dụng đúng KoiContext
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization; // Để áp dụng quyền

namespace KOI_XS.Presentation.Controllers
{
    [Authorize(Roles = "Admin")] // Đảm bảo quyền truy cập chỉ dành cho người dùng Admin
    public class AdminController : Controller
    {
        private readonly KoiContext _context; // Thay vì DbContext, chúng ta sử dụng KoiContext

        // Khởi tạo controller với KoiContext
        public AdminController(KoiContext context)
        {
            _context = context; // Sử dụng KoiContext thay vì DbContext
        }

        // Xem danh sách đơn hàng
        public IActionResult ManageOrders()
        {
            var orders = _context.Orders.ToList(); // Lấy tất cả đơn hàng từ DbSet Orders
            return View(orders); // Trả về view để hiển thị danh sách đơn hàng
        }

        // Xem chi tiết đơn hàng
        public IActionResult ViewOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id); // Lấy thông tin chi tiết đơn hàng theo id
            if (order == null)
            {
                return NotFound(); // Nếu không tìm thấy đơn hàng thì trả về lỗi 404
            }
            return View(order); // Trả về view để hiển thị chi tiết đơn hàng
        }

        // Thay đổi trạng thái đơn hàng
        [HttpPost]
        public IActionResult ChangeOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId); // Lấy đơn hàng theo ID
            if (order == null)
            {
                return NotFound(); // Nếu không tìm thấy đơn hàng thì trả về lỗi 404
            }

            order.Status = status; // Cập nhật trạng thái đơn hàng
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return RedirectToAction("ManageOrders"); // Quay lại danh sách đơn hàng
        }

        // Xóa đơn hàng
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id); // Lấy đơn hàng theo ID
            if (order != null)
            {
                _context.Orders.Remove(order); // Xóa đơn hàng khỏi cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return RedirectToAction("ManageOrders"); // Quay lại danh sách đơn hàng
        }

        // Quản lý khách hàng
        public IActionResult ManageCustomers()
        {
            var customers = _context.Customers.ToList(); // Lấy danh sách khách hàng từ DbSet Customers
            return View(customers); // Trả về view để hiển thị danh sách khách hàng
        }

        // Xem chi tiết khách hàng
        public IActionResult ViewCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id); // Lấy thông tin chi tiết khách hàng theo id
            if (customer == null)
            {
                return NotFound(); // Nếu không tìm thấy khách hàng thì trả về lỗi 404
            }
            return View(customer); // Trả về view để hiển thị chi tiết khách hàng
        }

        // Quản lý các loại cá Koi
        public IActionResult ManageKoi()
        {
            var koiList = _context.Kois.ToList(); // Lấy danh sách các loại cá Koi từ DbSet Kois
            return View(koiList); // Trả về view để hiển thị danh sách cá Koi
        }

        // Quản lý cá Koi
        public IActionResult ManageKoiFish()
        {
            var koiFishList = _context.KoiFishes.ToList(); // Lấy danh sách các con cá Koi từ DbSet KoiFishes
            return View(koiFishList); // Trả về view để hiển thị danh sách cá Koi
        }
    }
}
