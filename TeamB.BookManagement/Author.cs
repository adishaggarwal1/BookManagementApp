using DataAnnotationsExtensions;
using TeamB.Utils;

namespace TeamB.BookManagement
{
    public class Author
    {
        //[UniqueAuthorId]
        public string Id { get; set; }

        public string Name { get; set; }

        //[WordCount(10)]
        public string Biography { get; set; }

        public string Photo { get; set; }

        //[Email]
        public string? Email { get; set; }

        public override string ToString()
        {
            return $"Author[Id={Id} , Name={Name} ]";
        }
    }
}
