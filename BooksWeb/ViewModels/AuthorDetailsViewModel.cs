using TeamB.BookManagement;

namespace BooksWeb.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public Author Author {  get; set; }
        public List<Book> Books { get; set; }
    }
}
