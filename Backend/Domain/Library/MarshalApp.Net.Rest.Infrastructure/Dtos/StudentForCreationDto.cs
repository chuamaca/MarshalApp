namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class StudentForCreationDto
    {
        public StudentForCreationDto()
        {
            Grades = new List<GradeForCreationDto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string Gender { get; set; }
        public string Collegecareer { get; set; }

        public ICollection<GradeForCreationDto> Grades { get; set; }

    }
}
