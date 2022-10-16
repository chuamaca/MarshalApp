using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class GradeLinksBuilder : IGradeLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public GradeLinksBuilder(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }
        public GradeDto CreateDocumentationLinksForGrade(GradeDto grade)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            grade.Links.Add(new LinkDto(urlHelper.Link("GetGradeForStudent", new { estudianteId = grade.GradeId, id = grade.GradeId }), "self", "GET"));
            grade.Links.Add(new LinkDto(urlHelper.Link("DeleteGradeForStudent", new { estudianteId = grade.GradeId, id = grade.GradeId }), "delete_grade", "DELETE"));
            grade.Links.Add(new LinkDto(urlHelper.Link("UpdateGradeForStudent", new { estudianteId = grade.GradeId, id = grade.GradeId }), "update_grade", "PUT"));
            grade.Links.Add(new LinkDto(urlHelper.Link("PartiallyUpdateGradeForStudent", new { estudianteId = grade.GradeId, id = grade.GradeId }), "partially_update_grade", "PATCH"));

            return grade;
        }

        public LinkedCollectionResourceWrapperDto<GradeDto> CreateDocumentationLinksForGrades(LinkedCollectionResourceWrapperDto<GradeDto> cursosWrapper)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            cursosWrapper.Links.Add(new LinkDto(urlHelper.Link("GetGradesForStudent", new { }), "self", "GET"));

            return cursosWrapper;
        }

    }
}
