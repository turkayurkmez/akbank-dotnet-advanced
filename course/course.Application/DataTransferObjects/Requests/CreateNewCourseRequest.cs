﻿using System.ComponentModel.DataAnnotations;

namespace course.Application.DataTransferObjects.Requests
{
    public class CreateNewCourseRequest
    {
        [Required]
        [MaxLength(350)]
        [MinLength(3)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";
        public int? CategoryId { get; set; }
    }
}
