using Host.Common.Utilities;
using Host.DB.Entities;
using Host.DB.Repositories.Interfaces;
using Host.Services.Services.CoreBase;
using Host.Services.Services.Interfaces;
using System.Security;

namespace Host.Services.Services.Implementations
{
    public class AuthService : BaseService<Client>, IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository) : base(authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Client> Login(string username, string password)
        {
            var client = await _authRepository.GetClientByUsername(username);

            if (client == null)
            {
                throw new KeyNotFoundException("Username doesnt exists");
            }

            if (client.IsDeactivate)
            {
                throw new SecurityException("Client is Deactive");
            }

            //await Utility.IsValidPasscode(password);
            var passwordMatch = await VerifyLogin(client, password);

            if (!passwordMatch) throw new SecurityException("Password doesnt match");

            return client;
        }

        public async Task<bool> VerifyLogin(Client vm, string password)
        {
            var passwordMatch = false;

            //For case that already have password
            if (vm.Password != null)
            {
                passwordMatch = Utility.VerifyPassword(vm.Password, password, vm.PasscodeSalt);
            }
            //TODO Don't have password, using tempPassword => New user logic 
            else { }
            return passwordMatch;
        }
    }
}
