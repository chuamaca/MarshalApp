namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string Gender { get; set; }
        public string Collegecareer { get; set; }
    }
}
