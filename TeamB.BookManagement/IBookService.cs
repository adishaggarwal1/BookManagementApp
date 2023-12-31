﻿namespace TeamB.BookManagement
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(string id);
        Task<List<Book>> GetBooksByAuthor(string authorId);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(string bookId);
        Task<List<Book>> SearchBooks(string term);
    }
}
