using TeamB.BookManagement;
using TeamB.Utils;

namespace BooksWeb.ViewModels
{
    public class EditBookViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string? Cover_Photo { get; set; }

        [WordCount(10)]
        public string Description { get; set; }

        public Author Author { get; set; }
        public string AuthorId { get; set; }
    }
}
