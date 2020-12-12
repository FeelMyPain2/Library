using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Library.Web.Controllers
{
    public class SearchController : Controller
    {
        readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Index(string query)
        {
            var books = bookService.GetAllByQuery(query);

            return View(books);
        }
    }
}
