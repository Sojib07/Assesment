using Newtonsoft.Json;

namespace Assesment.Infrastructure.Models
{
    public class StackOverflowAnswerResponse
    {
        [JsonProperty("items")]
        public List<Answer> Answers { get; set; }
    }
}
