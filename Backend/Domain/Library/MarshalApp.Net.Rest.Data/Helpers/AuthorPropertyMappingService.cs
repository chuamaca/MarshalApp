using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.PropertyMapping;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Helpers
{
    public class AuthorPropertyMappingService : PropertyMappingService<AuthorDto, Author>, IAuthorPropertyMappingService
    {
        private static Dictionary<string, PropertyMappingValue> _authorPropertyMapping =
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
               { "Id", new PropertyMappingValue(new List<string>() { "Id" } ) },
               { "Genre", new PropertyMappingValue(new List<string>() { "Genre" } )},
               { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth" } , true) },
               { "Name", new PropertyMappingValue(new List<string>() { "FirstName", "LastName" }) }
           };
        public AuthorPropertyMappingService() : base(_authorPropertyMapping)
        {

        }
    }
}
