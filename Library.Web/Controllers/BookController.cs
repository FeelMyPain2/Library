using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class BookController : Controller
    {
        readonly IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Index(int id)
        {
            Book book = bookRepository.GetById(id);

            return View(book);
        }
    }
}
