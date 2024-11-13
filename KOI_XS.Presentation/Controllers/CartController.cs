using KOI_XS.DAL;
using KOI_XS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KOI_XS.Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly KoiContext _context;

        public CartController(KoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCartItems();
            return View(cart);
        }

      
        public IActionResult AddToCart(int id)
        {
            var koi = _context.Kois.Find(id);
            if (koi == null)
            {
                return NotFound();
            }

            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.Koi.KoiId == id);

            if (cartItem == null)
            {
                cart.Add(new CartItem { Koi = koi, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

            SaveCartSession(cart);
            return RedirectToAction("Index", "Koi");
        }

        
        public IActionResult Remove(int id)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.Koi.KoiId == id);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Index));
        }

       
        const string CARTKEY = "cart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsonCart = session.GetString(CARTKEY);
            if (!string.IsNullOrEmpty(jsonCart))
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsonCart);
            }
            return new List<CartItem>();
        }

        void SaveCartSession(List<CartItem> cart)
        {
            var session = HttpContext.Session;
            string jsonCart = JsonConvert.SerializeObject(cart);
            session.SetString(CARTKEY, jsonCart);
        }
    }

    
    public class CartItem
    {
        public Koi Koi { get; set; }
        public int Quantity { get; set; }
    }
}
