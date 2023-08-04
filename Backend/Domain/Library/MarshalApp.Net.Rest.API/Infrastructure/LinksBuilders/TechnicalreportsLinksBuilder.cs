using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class TechnicalreportsLinksBuilder : ITechnicalreportsLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;


        public TechnicalreportsLinksBuilder
        ( 
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor)
        {
            _urlHelperFactory =  urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }


        public List<LinkDto> CreateDocumentationLinksForTechnicalreports(Guid id, string fields)
        {
            var links = new List<LinkDto>();
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(new LinkDto(urlHelper.Link("GetTechnicalreports", new { id }), "self", "GET"));
            }
            else
            {
                links.Add(new LinkDto(urlHelper.Link("GetTechnicalreports", new { id, fields }), "self", "GET"));
            }

            links.Add(new LinkDto(urlHelper.Link("DeleteTechnicalreport", new { id }), "delete_technicalreport", "DELETE"));
           links.Add(new LinkDto(urlHelper.Link("CreateTechnicalreport", new { id = id }), "create_technicalreport", "POST"));
           // links.Add(new LinkDto(urlHelper.Link("GetGradesForStudent", new { estudianteId = id }), "cursos", "GET"));

            return links;
        }
    }
}
