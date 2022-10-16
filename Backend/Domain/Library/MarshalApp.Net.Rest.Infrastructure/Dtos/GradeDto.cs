using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class GradeDto : LinkedResourceBaseDto
    {
        public Guid GradeId { get; set; }
        public Guid StudentId { get; set; }
        public string Subject { get; set; }
        public decimal? Qualification { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string Status { get; set; }

    }
}
