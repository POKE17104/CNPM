using System.ComponentModel.DataAnnotations.Schema;

namespace KOI_XS.DAL.Entities
{
    public class OrderKoi
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int KoiFishId { get; set; }
        public KoiFish KoiFish { get; set; }
    }
}
