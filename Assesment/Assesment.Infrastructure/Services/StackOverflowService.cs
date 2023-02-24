using Assesment.Infrastructure.Models;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Assesment.Infrastructure.Services
{
    public class StackOverflowService : IStackOverflowService
    {

        public StackOverflowService()
        {
            
        }

        public async Task<IList<Answer>> GetAnswers(int id)
        {
            var client = new HttpClient();
            string answerUrl = $"https://api.stackexchange.com/2.3/answers/{id}?order=desc&sort=activity&site=stackoverflow";
            var response = await client.GetAsync(answerUrl);
            response.EnsureSuccessStatusCode();

            byte[] compressedData = await response.Content.ReadAsByteArrayAsync();
            using (var stream = new MemoryStream(compressedData))
            using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzip))
            {
                string json = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<StackOverflowAnswerResponse>(json);
                return data.Answers;
            }
        }

        public async Task<IList<Question>> GetQuestions()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.stackexchange.com/2.3/questions?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");
            response.EnsureSuccessStatusCode();

            byte[] compressedData = await response.Content.ReadAsByteArrayAsync();
            using (var stream = new MemoryStream(compressedData))
            using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzip))
            {
                string json = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<StackOverflowQuestionResponse>(json);
                return data.Questions;
            }
        }
    }
}