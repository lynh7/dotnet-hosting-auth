using BookManagement.IRepository;
using BookManagement.IServices;
using BookManagement.Model;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(Book obj)
        {
            return await _bookRepository.Add(obj);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            return await (_bookRepository.GetById(id));
        }

        public async Task<bool> RemoveBookAsync(string id)
        {
            return await _bookRepository.Remove(id);
        }

        public async Task<Book> UpdateBookAsync(string id, Book obj)
        {
            return await _bookRepository.Update(id, obj);
        }
    }
}
