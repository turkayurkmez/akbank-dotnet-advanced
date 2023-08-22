using System.ComponentModel.DataAnnotations;

namespace course.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(350)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
