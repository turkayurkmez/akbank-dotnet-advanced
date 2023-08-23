using course.Application.DataTransferObjects.Responses;

namespace course.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CourseListDisplayResponse> CourseLists { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
