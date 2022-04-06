namespace KitLapBackend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
