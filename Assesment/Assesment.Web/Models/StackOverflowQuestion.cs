using Newtonsoft.Json;

namespace Assesment.Web.Models
{
    public class StackOverflowQuestion
    {
        [JsonProperty("question_id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
