using MarshalApp.Net.Security.API.Infrastructure.Data.Contexts;
using MarshalApp.Net.Security.API.Infrastructure.Data.Repositories;

namespace MarshalApp.Net.Security.API.Infrastructure.Data.UnitOfWorks
{
    public class SecurityUnitOfWork : UnitOfWork
    {
        public IUserRepository Users;
        private SecurityContext _context;
        public SecurityUnitOfWork(
            SecurityContext context,
            IUserRepository userRepository
        ) : base(context)
        {
            _context = context;
            Users = userRepository;
        }
    }
}
