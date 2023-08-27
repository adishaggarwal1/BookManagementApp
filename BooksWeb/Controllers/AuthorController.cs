using BooksWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TeamB.BookManagement;

namespace BooksWeb.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService authorService;
        IBookService bookService;

        public AuthorController(IAuthorService authors, IBookService bookService)
        {
            this.authorService = authors;
            this.bookService = bookService;
        }

        public async Task<ViewResult> Index()
        {
            var authors = await authorService.GetAllAuthors();

            return View(authors);
        }

        public async Task<ViewResult> Details(string id)
        {
            var author = await authorService.GetAuthorById(id);

            return View(author);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Author());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Author author)
        {
            if(ModelState.IsValid)
            {
                await authorService.AddAuthor(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public async Task<ViewResult> Edit(string id)
        {
            var author = await authorService.GetAuthorById(id);
            return View(author);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Author author)
        {
            await authorService.UpdateAuthor(author);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string id)
        {
            await authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> AuthorDetails(string Id)
        {
            var author = await authorService.GetAuthorById(Id);
            var books = await bookService.GetBooksByAuthor(Id);

            var vm = new AuthorDetailsViewModel()
            {
                Author = author,
                Books = books
            };

            return View(vm);
        }
    }
}
