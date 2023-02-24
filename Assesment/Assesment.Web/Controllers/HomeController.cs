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
            //Retrieving data for test purpose
            var bookModel = _scope.Resolve<BookModel>();
            var books=await bookModel.GetAllBooks();
            var booksWithSP= await bookModel.GetAllBooksWithStoredProcedure();

            //Retrieving data for test purpose
            var authorModel = _scope.Resolve<AuthorModel>();
            var authors = await authorModel.GetAllAuthors();
            var authorsWithSP = await authorModel.GetAllAuthorsWithStoredProcedure();

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public async Task<IActionResult> DropDown()
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