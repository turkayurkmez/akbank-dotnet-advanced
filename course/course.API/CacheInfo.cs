using course.Application.DataTransferObjects.Responses;

namespace course.API
{
    public class CacheInfo
    {
        public DateTime CacheTime { get; set; }
        public IEnumerable<CourseListDisplayResponse> Courses { get; set; }
    }
}
