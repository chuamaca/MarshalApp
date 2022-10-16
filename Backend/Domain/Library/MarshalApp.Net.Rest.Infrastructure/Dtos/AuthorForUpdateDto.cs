namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorForUpdateDto
    {
        public AuthorForUpdateDto()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

    }
}
