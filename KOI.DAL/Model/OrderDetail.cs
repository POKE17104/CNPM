namespace KOI.DAL.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int FishId { get; set; }
        public Fish Fish { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
