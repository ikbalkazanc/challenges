using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pazarama.Homework.Core.Contracts.Service;
using Pazarama.Homework.Core.Entity;
using Pazarama.Homework.Data;
using Pazarama.Homework.Services.Services;

namespace Pazarama.Homework.Web.Controllers
{
    public class BooksController : Controller
    {
        private BookService _bookService;

        public BooksController(IBookSevice bookSevice)
        {
            _bookService = (BookService)bookSevice;
        }

        // GET: BooksController
        public async Task<IActionResult> Index([FromQuery]int? categoryId)
        {
            var books = await _bookService.GetAllBooks(categoryId);
            return View(books);
        }

        // GET: BooksController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetDetails(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book model)
        {
            await _bookService.CreateBook(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: BooksController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetDetails(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Book model)
        {
           await _bookService.UpdateBook(id, model);
     
            return RedirectToAction(nameof(Index));
        }

        // GET: BooksController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
         await _bookService.RemoveBook(id);

            return RedirectToAction("Index");
        }

    }
}
