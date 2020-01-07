namespace BooksCatalogueAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}