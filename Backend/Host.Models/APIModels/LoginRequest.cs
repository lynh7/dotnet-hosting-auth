namespace Host.Models.APIModels
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            Username = String.Empty;
            Password = String.Empty;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
