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
            if(ModelState.ErrorCount == 1 && ModelState["Author"].Errors.Count == 1)
            {
                await bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<ViewResult> Edit(string id)
        {
            var book = await bookService.GetBookById(id);
            var vm = new EditBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Cover_Photo = book.Cover_Photo,
                Description = book.Description,
                AuthorId = book.AuthorId,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditBookViewModel vm)
        {
            if(ModelState.ErrorCount == 1 && ModelState["Author"].Errors.Count == 1) 
            {
                var book = new Book()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    Cover_Photo = vm.Cover_Photo,
                    Description = vm.Description,
                    AuthorId = vm.AuthorId,
                };
                await bookService.UpdateBook(book);
                return RedirectToAction("BookDetails", new { Id = book.Id });
            }
            return View(vm);
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
