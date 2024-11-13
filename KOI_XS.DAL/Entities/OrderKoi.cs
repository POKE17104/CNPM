using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOI_XS.DAL.Entities
{
    public class OrderKoi
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key, Column(Order = 1)]
        public int KoiFishId { get; set; }
        public KoiFish KoiFish { get; set; }

        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } = 0;
    }
}
