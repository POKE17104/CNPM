namespace KOI.DAL.Models
{
    public class Fish
    {
        public int FishId { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
