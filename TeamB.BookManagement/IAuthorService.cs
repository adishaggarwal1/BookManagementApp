namespace TeamB.BookManagement
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(string id);
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task DeleteAuthor(string authorId);
        Task<List<Author>> SearchAuthors(string term);
    }
}
