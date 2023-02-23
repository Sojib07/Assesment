using Assesment.API.Models;
using Assesment.Infrastructure.BusinessObjects;
using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IEnumerable<Book>> Get()
        {
            try
            {
                var model = _scope.Resolve<BookModel>();
                return await model.GetBooks();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get books");
                return null;
            }
        }
    }
}