using Host.DB.Entities;
using Host.DB.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DB.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
