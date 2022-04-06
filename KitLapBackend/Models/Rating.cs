namespace KitLapBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
