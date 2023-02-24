using Newtonsoft.Json;

namespace Assesment.Infrastructure.Models
{
    public class StackOverflowQuestionResponse
    {
        [JsonProperty("items")]
        public List<Question> Questions { get; set; }
    }
}