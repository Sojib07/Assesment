using Assesment.Web.Models;
using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Web.Controllers
{
    public class StackOverflowController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<StackOverflowController> _logger;
        public StackOverflowController(ILogger<StackOverflowController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }
        
        public async Task<IActionResult> Questions()
        {
            try
            {
                var model = _scope.Resolve<QuestionModel>();
                var questionList= await model.GetQuestions();

                return View(questionList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get questions");
                return null;
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = _scope.Resolve<AnswerModel>();
                var answerList = await model.GetAnswers(id);

                return View(answerList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get answers");
                return null;
            }
        }
    }
}
