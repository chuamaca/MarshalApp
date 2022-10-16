namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder
{
    public abstract class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
