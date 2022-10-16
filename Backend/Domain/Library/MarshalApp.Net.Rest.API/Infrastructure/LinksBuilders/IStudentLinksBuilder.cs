using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using System.Dynamic;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface IStudentLinksBuilder
    {
        string CreateStudentsResourceUri(StudentsResourceParameters studentsResourceParameters, ResourceUriType type);
        List<LinkDto> CreateDocumentationLinksForStudent(Guid id, string fields);
        IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForStudentShapeData(IEnumerable<ExpandoObject> shapedStudents, StudentsResourceParameters studentsResourceParameters);
        IEnumerable<LinkDto> CreatePagedLinksForStudents(StudentsResourceParameters studentsResourceParameters, bool hasNext, bool hasPrevious);
        PaginationMetadata GetPaginationMetadata(PagedList<Student> students, StudentsResourceParameters studentsResourceParameters);

    }
}
