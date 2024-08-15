using Host.DB.Entities;

namespace Host.Models.APIModels
{
    public class LoginResponse
    {
        public LoginResponse()
        {
        }

        public LoginResponse(string message) { }
        public LoginResponse(Client client) : this()
        {
            this.ClientId = client.Id;
            this.ClientName = client.Name;
        }

        public Guid ClientId { get; set; }
        public string ClientName { get; set; }

    }
}
