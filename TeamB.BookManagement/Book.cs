﻿namespace TeamB.BookManagement
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Cover_Photo { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }
        public string AuthorId { get; set; }

        public override string ToString()
        {
            return $"Book[Id={Id} , Title={Title} ]";
        }
    }
}
