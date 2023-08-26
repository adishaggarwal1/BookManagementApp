using BooksWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TeamB.BookManagement;

namespace BooksWeb.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IReviewService reviewService;
        public BookController(IBookService books, IReviewService reviewService)
        {
            this.bookService = books;
            this.reviewService = reviewService;
        }
        public async Task<ViewResult> Index()
        {
            var books = await bookService.GetAllBooks();

            return View(books);
        }

        public async Task<ViewResult> Details(string id)
        {
            var book = await bookService.GetBookById(id);

            return View(book);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Book());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            await bookService.AddBook(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ViewResult> Edit(string id)
        {
            var author = await bookService.GetBookById(id);
            return View(author);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book book)
        {
            await bookService.UpdateBook(book);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string id)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> BookDetails(string Id)
        {
            var book = await bookService.GetBookById(Id);
            var reviews = await reviewService.GetReviewsByBook(Id);

            var vm = new BookDetailsViewModel
            {
                Book = book,
                Reviews = reviews
            };

            return View(vm);
        }
    }
}
