namespace course.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
