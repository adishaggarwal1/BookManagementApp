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
            var vm = new EditAuthorViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Photo = author.Photo,
                Email = author.Email
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditAuthorViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var author = new Author()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Biography = vm.Biography,
                    Photo = vm.Photo,
                    Email = vm.Email
                };
                await authorService.UpdateAuthor(author);
                return RedirectToAction("AuthorDetails", new { Id = author.Id });
            }
            return View(vm);
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
