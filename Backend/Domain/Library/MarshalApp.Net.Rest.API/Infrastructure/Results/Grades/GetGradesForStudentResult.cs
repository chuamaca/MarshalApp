using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Grades
{
    public class GetGradesForStudentResult
    {
        public LinkedCollectionResourceWrapperDto<GradeDto> LinkedCollectionResource { get; set; }
    }
}
