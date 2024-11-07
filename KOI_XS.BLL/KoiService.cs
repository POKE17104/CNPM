
using KOI_XS.DAL;
using KOI_XS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KOI_XS.BLL
{
    public class KoiService
    {
        private readonly KoiContext _context;

        public KoiService(KoiContext context)
        {
            _context = context;
        }

        // Lấy tất cả cá KoiFish
        public async Task<IEnumerable<KoiFish>> GetAllKoiAsync()
        {
            return await _context.KoiFishes.ToListAsync();
        }

        // Lấy cá KoiFish theo ID
        public async Task<KoiFish> GetKoiByIdAsync(int id)
        {
            return await _context.KoiFishes.FindAsync(id);
        }

        // Thêm mới cá KoiFish
    public async Task<KoiFish> AddKoiAsync(Koi koi)
{
   
    var koiFish = new KoiFish
    {
       KoiFishId = koi.KoiId,   
        Name = koi.Name,         
        Color = koi.Color,       
        Price = koi.Price,
        Breed = koi.Breed,      
        ImageUrl = koi.ImageUrl       
        
    };

    
    _context.KoiFishes.Add(koiFish);
    await _context.SaveChangesAsync();
    return koiFish;
}



        // Cập nhật thông tin cá KoiFish
        public async Task<bool> UpdateKoiAsync(KoiFish koiFish)
        {
            _context.KoiFishes.Update(koiFish);
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Xóa cá KoiFish
        public async Task<bool> DeleteKoiAsync(int id)
        {
            var koiFish = await _context.KoiFishes.FindAsync(id);
            if (koiFish == null)
                return false;

            _context.KoiFishes.Remove(koiFish);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
