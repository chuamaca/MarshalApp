using System.ComponentModel.DataAnnotations;

namespace MarshalApp.Net.Security.API.Infrastructure.Dtos
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
