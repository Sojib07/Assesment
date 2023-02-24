using Assesment.Infrastructure.Models;
using Assesment.Infrastructure.Services;
using Autofac;
using AutoMapper;

namespace Assesment.Web.Models
{
    public class QuestionModel
    {
        private IStackOverflowService? _stackOverflowService;
        private IMapper _mapper;
        public int question_id { get; set; }
        public string Title { get; set; }

        public QuestionModel()
        {

        }

        public QuestionModel(IStackOverflowService stackOverflowService, IMapper mapper)
        {
            _stackOverflowService = stackOverflowService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _stackOverflowService = scope.Resolve<IStackOverflowService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public async Task<IList<Question>> GetQuestions()
        {
            return await _stackOverflowService.GetQuestions();
        }
    }
}
