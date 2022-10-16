using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.StudentCollections
{
    public class CreateStudentCollectionResult
    {
        public IEnumerable<StudentDto> StudentCollection { get; set; }
        public string IdsAsString { get; set; }
    }
}
