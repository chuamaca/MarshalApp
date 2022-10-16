using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.PropertyMapping;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Helpers
{
    public interface IAuthorPropertyMappingService : IPropertyMappingService<AuthorDto, Author>
    {

    }
}
