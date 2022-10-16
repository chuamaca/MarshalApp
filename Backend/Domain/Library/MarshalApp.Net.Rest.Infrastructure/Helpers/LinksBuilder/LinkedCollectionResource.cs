namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder
{
    public class LinkedCollectionResource
    {
        public IEnumerable<IDictionary<string, object>> Value { get; set; }
        public IEnumerable<LinkDto> Links { get; set; }
    }
}
