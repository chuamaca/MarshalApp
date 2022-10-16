using MarshalApp.Net.Security.API.Infrastructure.Data.Contexts;
using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Security.API.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityContext _context;
        public UserRepository(SecurityContext context)
        {
            _context = context;
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
