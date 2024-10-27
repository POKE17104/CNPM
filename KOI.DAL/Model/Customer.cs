namespace KOI.DAL.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get => FullName1; set => FullName1 = value; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string FullName1 { get; set; }
    }
}
