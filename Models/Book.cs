using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksCatalogue.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        [Required]
        public string Author { get; set; }
        [JsonPropertyName("synopsis")]
        [Required]
        public string Synopsis { get; set; }
        [Display(Name = "Release Year")]
        [JsonPropertyName("releaseYear")]
        [Required]
        public int ReleaseYear { get; set; }
        [Display(Name = "Cover URL")]
        [JsonPropertyName("coverURL")]
        [Required]
        public string CoverURL { get; set; }
        [JsonPropertyName("reviews")]
        public ICollection<Review> Reviews { get; set; }
    }
}