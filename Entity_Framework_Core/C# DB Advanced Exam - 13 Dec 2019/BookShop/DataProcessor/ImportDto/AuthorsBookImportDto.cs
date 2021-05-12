using Newtonsoft.Json;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorsBookImportDto
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}