using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Book> books = _bookService.ViewBooks() ?? new();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var book = _bookService.GetBookById(Id);
            if(book == null)
            {
                return NotFound();
            }

            return View(book);
        } 

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if(ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            _bookService.DeleteBook(bookId);

            return RedirectToAction("Index");
        }
    }
}
