namespace course.Application.DataTransferObjects.Responses
{
    public class CourseListDisplayResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";

        public int? CategoryId { get; set; }
    }
}
