using BookManagement.IRepository;
using BookManagement.Model;
using BookManagement.MongoDB;
using BookManagement.MongoDB.Repository;

namespace BookManagement.Repository
{
    public class BookRepository : MongoRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoService context) : base(context)
        {
        }
    }
}
