using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamB.BookManagement
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviewer_Email { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public Book Book { get; set; }
        public string Book_Id { get; set; }
    }
}
