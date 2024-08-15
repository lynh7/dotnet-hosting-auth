using Host.DB.Entities;
using Host.DB.Repositories.Implementations.Base;
using Host.DB.Repositories.Interfaces;
using Host.DB.UnitOfWorkPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Host.DB.Repositories.Implementations
{
    public class AuthRepository : BaseRepository<Client>, IAuthRepository
    {
        public AuthRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Client> GetClientByUsername(string username)
        {
            username = username.ToLower();

            var query = from b in Table
                        where b.Username == username
                        where !b.IsDeleted
                        select b;

            var tCount = query.CountAsync();
            Console.WriteLine(tCount.Result);
            if (tCount.Result > 1) throw new System.Exception($"There is more than one matched entity with username: {username}");

            var tFirstOrDefaultAsync = query.FirstOrDefaultAsync();
            var user = await tFirstOrDefaultAsync;

            if (tFirstOrDefaultAsync.Status == TaskStatus.Faulted)
            {
                return await Task.FromException<Client>(new System.Exception("GetClientByUsername FirstOrDefaultAsync faield"));
            }

            if (user == null)
            {
                return await Task.FromException<Client>(new KeyNotFoundException("Username doesnt existed!"));
            }

            return user;
        }
    }
}
