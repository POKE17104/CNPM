using KOI_XS.DAL.Entities;

public class KoiFish
{
    public int KoiFishId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }

    // Đảm bảo kiểu của OrderKois là ICollection<OrderKoi> thay vì object
    public ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();
    
}
