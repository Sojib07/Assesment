using Assesment.API.Models;
using Assesment.Infrastructure.BusinessObjects;
using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        [HttpGet]
        [Route("GetAuthors")]
        public async Task<IEnumerable<Author>> Get()
        {
            try
            {
                var model = _scope.Resolve<AuthorModel>();
                return await model.GetAuthors();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get authors");
                return null;
            }
        }
    }
}