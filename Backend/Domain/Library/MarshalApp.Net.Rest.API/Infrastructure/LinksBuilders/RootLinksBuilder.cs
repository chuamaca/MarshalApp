using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class RootLinksBuilder : IRootLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;
        public RootLinksBuilder(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }
        public List<LinkDto> CreateDocumentationLinksForRoot()
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var links = new List<LinkDto>();

            links.Add(new LinkDto(urlHelper.Link("GetRoot", new { }), "self", "GET"));
            links.Add(new LinkDto(urlHelper.Link("GetAuthors", new { }), "authors", "GET"));
            links.Add(new LinkDto(urlHelper.Link("CreateAuthor", new { }), "create_author", "POST"));

            return links;
        }
    }
}
