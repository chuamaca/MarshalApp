using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using System.Dynamic;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Students
{
    public class GetStudentsResult
    {
        public IEnumerable<ExpandoObject> ShapedStudents { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
        public LinkedCollectionResource LinkedCollectionResource { get; set; }
    }
}
