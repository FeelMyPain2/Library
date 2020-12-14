using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class OrderController : Controller
    {
        readonly IBookRepository bookRepository;
        readonly IOrderRepository orderRepository;

        public OrderController(IBookRepository bookRepository,
            IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out RentalCart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderDto model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        public IActionResult AddItem(int id)
        {
            Order order;
            RentalCart cart;

            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new RentalCart(order.Id);

            }
            Book book = bookRepository.GetById(id);
            order.AddItem(book, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalRentalPrice = order.TotalRentalPrice;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }

        private OrderDto Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var books = bookRepository.GetAllByIds(bookIds);
            var itemModels = from item in order.Items
                             join book in books on item.BookId equals book.Id
                             select new OrderItemDto
                             {
                                 BookId = book.Id,
                                 Title = book.Title,
                                 Author = book.Author,
                                 RentalPrice = item.RentalPrice,
                                 Count = item.Count,
                             };

            return new OrderDto
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalRentalPrice = order.TotalRentalPrice,
                Date = order.Date
            };
        }
    }
}

