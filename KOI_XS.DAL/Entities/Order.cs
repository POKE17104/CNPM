using KOI_XS.DAL.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public Customer Customer { get; set; }
    public ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();
}
