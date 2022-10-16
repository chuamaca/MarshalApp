using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Root
{
    public class GetRootResult
    {
        public List<LinkDto> LinkedResources { get; set; }
    }
}
