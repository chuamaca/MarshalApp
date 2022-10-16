namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorForCreationDto
    {
        public AuthorForCreationDto()
        {
            Books = new List<BookForCreationDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<BookForCreationDto> Books { get; set; }
    }
}
