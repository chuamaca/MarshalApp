namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class StudentForUpdateDto
    {
        public StudentForUpdateDto()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string Gender { get; set; }
        public string Collegecareer { get; set; }

    }
}
