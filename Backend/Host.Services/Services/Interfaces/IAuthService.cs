using Host.DB.Entities;
using Host.Services.Services.CoreBase;

namespace Host.Services.Services.Interfaces
{
    public interface IAuthService : IBaseService<Client>
    {
        Task<Client> Login(string username, string password);
    }
}
