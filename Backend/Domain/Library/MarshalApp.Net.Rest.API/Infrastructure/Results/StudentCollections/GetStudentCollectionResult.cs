using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.StudentCollections
{
    public class GetStudentCollectionResult
    {
        public IEnumerable<StudentDto> StudentCollection { get; set; }
        public bool StudentsFound { get; set; }
    }
}
