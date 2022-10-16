namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public abstract class BookForManipulationDto
    {
        public string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
