using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Security.API.Infrastructure.Dtos
{
    public class AuthenticateResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public AuthenticateResponse(User user, string bearerToken, bool isAuthenticated)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.Username;
            BearerToken = bearerToken;
            IsAuthenticated = isAuthenticated;
        }
    }
}
