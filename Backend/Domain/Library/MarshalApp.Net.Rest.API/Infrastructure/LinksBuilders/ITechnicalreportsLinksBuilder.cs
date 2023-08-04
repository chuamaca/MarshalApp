using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface ITechnicalreportsLinksBuilder
    {
        List<LinkDto> CreateDocumentationLinksForTechnicalreports(Guid id, string fields);
    }
}
