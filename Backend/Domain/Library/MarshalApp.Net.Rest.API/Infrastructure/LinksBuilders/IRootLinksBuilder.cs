using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface IRootLinksBuilder
    {
        List<LinkDto> CreateDocumentationLinksForRoot();
    }
}