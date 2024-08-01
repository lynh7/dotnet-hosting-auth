using BookManagement.IRepository.Base;
using BookManagement.Model;

namespace BookManagement.IRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
