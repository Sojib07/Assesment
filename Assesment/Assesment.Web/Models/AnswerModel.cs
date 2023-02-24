using Assesment.Infrastructure.Models;
using Assesment.Infrastructure.Services;
using Autofac;
using AutoMapper;

namespace Assesment.Web.Models
{
    public class AnswerModel
    {
        private IStackOverflowService? _stackOverflowService;
        private IMapper _mapper;
        public string is_accepted { get; set; }
        public long score { get; set; }
        public int answer_id { get; set; }

        public AnswerModel()
        {

        }

        public AnswerModel(IStackOverflowService stackOverflowService, IMapper mapper)
        {
            _stackOverflowService = stackOverflowService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _stackOverflowService = scope.Resolve<IStackOverflowService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public async Task<IList<Answer>> GetAnswers(int id)
        {
            return await _stackOverflowService.GetAnswers(id);
        }
    }
}
