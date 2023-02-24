using Assesment.Infrastructure.Models;

namespace Assesment.Infrastructure.Services
{
    public interface IStackOverflowService
    {
        Task<IList<Answer>> GetAnswers(int id);
        Task<IList<Question>> GetQuestions();
    }
}
