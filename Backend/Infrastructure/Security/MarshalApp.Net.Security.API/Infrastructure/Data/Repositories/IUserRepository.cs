using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Security.API.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUserByUsernameAndPassword(string username, string password);
    }
}