using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksCatalogue.Models
{
    public class Review
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("bookId")]
        public int BookId { get; set; }
        [JsonPropertyName("reviewerName")]
        public string ReviewerName { get; set; }
        [JsonPropertyName("rating")]
        [Range(1, 10)]
        public int Rating { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
        public Book Book { get; set; }
    }
}