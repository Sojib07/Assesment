using Assesment.Infrastructure.Services;
using Assesment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assesment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IAuthorService authorService, IBookService bookService)
        {
            _logger = logger;
            _authorService = authorService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var list= await _authorService.GetAllAuthors();
            var list2= await _bookService.GetAllBooks();
            var list3 = await _bookService.GetAllBooksWithStoredProcedure();
            var list4 = await _authorService.GetAllAuthorsWithStoredProcedure();

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