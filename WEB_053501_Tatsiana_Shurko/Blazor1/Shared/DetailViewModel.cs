using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor1.Shared {
    public class DetailViewModel {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("discription")]
        public string? Discription { get; set; }

        [JsonPropertyName("price")]
        public float? Price { get; set; }

        [JsonPropertyName("imagePath")]
        public string? ImagePath { get; set; }

        [JsonPropertyName("mimeType")]
        public string? MimeType { get; set; }
    }
}
