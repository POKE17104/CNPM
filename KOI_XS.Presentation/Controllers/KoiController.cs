
using Microsoft.AspNetCore.Mvc;
using KOI_XS.BLL;
using KOI_XS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KOI_XS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiController : ControllerBase
    {
        private readonly KoiService _koiService;

        public KoiController(KoiService koiService)
        {
            _koiService = koiService;
        }

        // GET: api/Koi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KoiFish>>> GetKoi()
        {
            var kois = await _koiService.GetAllKoiAsync();
            return Ok(kois);
        }

        // GET: api/Koi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KoiFish>> GetKoi(int id)
        {
            var koi = await _koiService.GetKoiByIdAsync(id);
            if (koi == null)
                return NotFound();

            return Ok(koi);
        }

        // POST: api/Koi
        [HttpPost]
        public async Task<ActionResult<KoiFish>> PostKoi(KoiFish koiFish)
        {
            var createdKoi = await _koiService.AddKoiAsync(koiFish);
            return CreatedAtAction(nameof(GetKoi), new { id = createdKoi.KoiFishId }, createdKoi);
        }

        // PUT: api/Koi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKoi(int id, KoiFish koiFish)
        {
            if (id != koiFish.KoiFishId)
                return BadRequest();

            var result = await _koiService.UpdateKoiAsync(koiFish);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Koi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoi(int id)
        {
            var result = await _koiService.DeleteKoiAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
