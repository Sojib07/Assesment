using Newtonsoft.Json;

namespace Assesment.Web.Models
{
    public class StackOverflowResponse
    {
        [JsonProperty("items")]
        public List<QuestionModel> Questions { get; set; }
    }
}
