namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public abstract class GradeForManipulationDto
    {

        public virtual string Subject { get; set; }
        public virtual decimal Qualification { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTimeOffset StartDate { get; set; }
        public virtual string Status { get; set; }
    }
}
