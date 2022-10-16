namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}
