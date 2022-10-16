using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarshalApp.Net.Security.API.Infrastructure.Data.Contexts
{
    public partial class SecurityContext : DbContext
    {
        public void EnsuredSeedDataForContext()
        {
            Database.Migrate();

            Users.RemoveRange(Users);
            SaveChanges();

            List<User> users = new List<User>
            {
                new User {
                    UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Cesar",
                    LastName = "Huamani",
                    Username = "cesar@gmail.com",
                    Password = "admin1234",
                    CanAccessAuthors= true,
                    CanAccessBooks= true,
                    CanAddAuthor= true,
                    CanSaveAuthor=true,
                    CanAccessStudent=true,
                    CanAccessGrades=true,
                    CanAddStudent=true,
                    CanSaveStudent=true,
                },
                new User {
                    UserId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Yuli",
                    LastName = "Alicia Lopez",
                    Username = "Yuli@mp.com",
                    Password = "#Admin#1",
                    CanAccessAuthors= true,
                    CanAccessBooks= true,
                    CanAddAuthor= false,
                    CanSaveAuthor=false,
                    CanAccessStudent=false,
                    CanAccessGrades=false,
                    CanAddStudent=false,
                    CanSaveStudent=false,
                }
            };

            Users.AddRange(users);
            SaveChanges();
        }
    }
}
