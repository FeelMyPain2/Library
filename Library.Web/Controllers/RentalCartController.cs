using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class RentalCartController : Controller
    {
        readonly IBookRepository bookRepository;
        public RentalCartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Add(int id)
        {
            Book book = bookRepository.GetById(id);
            RentalCart cart;

            if (!HttpContext.Session.TryGetCart(out cart))
            {
                cart = new RentalCart();
            }
            if (cart.Items.ContainsKey(id))
            {
                cart.Items[id]++;
            }
            else
            {
                cart.Items[id] = 1;
            }
            cart.RentalAmount += book.RentalPrice;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}
