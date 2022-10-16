using MarshalApp.Net.Security.API.Infrastructure.Dtos;

namespace MarshalApp.Net.Security.API.Application
{
    public interface ISecurityService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        IEnumerable<UserDto> GetAll();
    }
}