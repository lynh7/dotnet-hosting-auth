using Host.DB.Entities;
using Host.DB.Repositories.Implementations.Base;
using Host.DB.Repositories.Interfaces;
using Host.DB.UnitOfWorkPattern.Interfaces;

namespace Host.DB.Repositories.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
