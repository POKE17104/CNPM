using KOI_XS.BLL;
using KOI_XS.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KOI_XS.Presentation.Controllers
{
    public class KoiController : Controller
    {
        private readonly KoiService _koiService;

        public KoiController(KoiService koiService)
        {
            _koiService = koiService;
        }

        public async Task<IActionResult> Index()
        {
            var koiList = await _koiService.GetAllKoiAsync();
            return View(koiList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var koi = await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Koi koi)
        {
            if (ModelState.IsValid)
            {
                await _koiService.AddKoiAsync(koi);
                return RedirectToAction(nameof(Index));
            }
            return View(koi);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var koi = await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Koi koi)
        {
            if (id != koi.KoiId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _koiService. UpdateKoiAsync(koi);
                if (result)
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(koi);
        }

       
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var koi = await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
            {
                return NotFound();
            }
            return View(koi);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _koiService.DeleteKoiAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
