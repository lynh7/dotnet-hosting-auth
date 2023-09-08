using BookManagement.Model;

namespace BookManagement.IServices
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(Book obj);
        Task<Book> UpdateBookAsync(string id, Book obj);
        Task<bool> RemoveBookAsync(string id);
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> GetAll();
    }
}
