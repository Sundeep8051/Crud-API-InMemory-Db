using MovieStoreApi.Models;

namespace MovieStoreApi.Services
{
    public interface IBookLibrary
    {
        Task<List<Book>> GetBooks();
        Task<Book>? GetBookById(int id);
        Task<int> AddBook(Book book);
        Task<Book>? UpdateBook(Book book);
        Task<int> DeleteBook(int id);
    }
}