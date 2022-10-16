namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public string PreviousPageLink { get; set; }
        public string NextPageLink { get; set; }
    }
}
