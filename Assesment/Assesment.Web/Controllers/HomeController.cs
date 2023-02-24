using Assesment.Infrastructure.Services;
using Assesment.Web.Models;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assesment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public async Task<IActionResult> Index()
        {
            var bookModel = _scope.Resolve<BookModel>();
            var authorModel=_scope.Resolve<AuthorModel>();

            var a = bookModel.GetAllBooks();
            var b=bookModel.GetAllBooksWithStoredProcedure();

            var c = authorModel.GetAllAuthors();
            var d = authorModel.GetAllAuthorsWithStoredProcedure();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}