using Host.DB.Entities;
using Host.DB.Repositories.Interfaces;
using Host.Services.Services.CoreBase;
using Host.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Services.Services.Implementations
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
