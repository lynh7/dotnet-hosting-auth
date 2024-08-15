using Host.DB.Entities;
using Host.DB.Repositories.Interfaces.Base;

namespace Host.DB.Repositories.Interfaces
{
    public interface IAuthRepository : IBaseRepository<Client>
    {
        Task<Client> GetClientByUsername(string username);
    }
}
