using DataAnnotationsExtensions;
using TeamB.BookManagement;
using TeamB.Utils;

namespace BooksWeb.ViewModels
{
    public class EditAuthorViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [WordCount(10)]
        public string Biography { get; set; }

        public string? Photo { get; set; }

        [Email]
        public string? Email { get; set; }
    }
}
