using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface IGradeLinksBuilder
    {
        GradeDto CreateDocumentationLinksForGrade(GradeDto grade);
        LinkedCollectionResourceWrapperDto<GradeDto> CreateDocumentationLinksForGrades(LinkedCollectionResourceWrapperDto<GradeDto> gradesWrapper);
    }
}
