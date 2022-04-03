namespace KokoPizza.Core.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
