using Newtonsoft.Json;

namespace Assesment.Web.Models
{
    public class StackOverflowApiResponse<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("quota_max")]
        public int QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public int QuotaRemaining { get; set; }
    }
}
