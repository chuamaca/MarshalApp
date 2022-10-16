
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.PropertyMapping;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Helpers
{
    public class StudentPropertyMappingService : PropertyMappingService<StudentDto, Student>, IStudentPropertyMappingService
    {

        private static Dictionary<string, PropertyMappingValue> _studentPropertyMapping =
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
               { "Id", new PropertyMappingValue(new List<string>() { "Id" } ) },
               { "Gender", new PropertyMappingValue(new List<string>() { "Gender" } )},
               { "collegecareer", new PropertyMappingValue(new List<string>() { "collegecareer" } )},
              // { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth" } , true) },
               { "Name", new PropertyMappingValue(new List<string>() { "FirstName", "LastName" }) }
           };
        public StudentPropertyMappingService() : base(_studentPropertyMapping)
        {

        }
    }
}
