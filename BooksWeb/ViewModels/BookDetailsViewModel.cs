using TeamB.BookManagement;

namespace BooksWeb.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
