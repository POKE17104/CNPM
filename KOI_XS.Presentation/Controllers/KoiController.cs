using KOI_XS.BLL;
using KOI_XS.BLL; 
using KOI_XS.DAL.Entities;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(Koi koi)
{
    if (ModelState.IsValid)
    {
        await _koiService.AddKoiAsync(koi);
        return RedirectToAction(nameof(Index));
    }
    return View(koi);
}

    }
}
