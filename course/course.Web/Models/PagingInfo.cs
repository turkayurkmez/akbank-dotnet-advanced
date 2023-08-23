namespace course.Web.Models
{
    public class PagingInfo
    {
        public int TotalItemsCount { get; set; }
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get => (int)Math.Ceiling((decimal)TotalItemsCount / PageSize); }
    }
}
