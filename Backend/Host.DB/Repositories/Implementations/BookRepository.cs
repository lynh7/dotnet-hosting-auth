using Host.DB.Entities;
using Host.DB.Repositories.Implementations.Base;
using Host.DB.Repositories.Interfaces;
using Host.DB.UnitOfWorkPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DB.Repositories.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
