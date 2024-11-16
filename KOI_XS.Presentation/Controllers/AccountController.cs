using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KOI_XS.DAL.Entities;
using KOI_XS.Presentation.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace KOI_XS.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, 
                                 SignInManager<IdentityUser> signInManager, 
                                 ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

     
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    
                    var customer = new Customer
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Password = model.Password, 
                        Name = model.Name,
                        Address = model.Address,
                        PhoneNumber = model.PhoneNumber
                    };

                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();

                    // Đăng nhập người dùng sau khi đăng ký thành công
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Đăng nhập không thành công.");
            }
            return View(model);
        }

      
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var customer = _context.Customers.FirstOrDefault(c => c.Username == user.UserName);
            if (customer == null) return NotFound();

            var model = new ProfileViewModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == model.CustomerId);
            if (customer == null) return NotFound();

           
            customer.Name = model.Name;
            customer.Address = model.Address;
            customer.PhoneNumber = model.PhoneNumber;

            if (!string.IsNullOrEmpty(model.Password))
            {
                customer.Password = model.Password;
            }

            await _context.SaveChangesAsync();
            ViewBag.Message = "Cập nhật thông tin thành công!";
            return View(model);
        }
    }
}
