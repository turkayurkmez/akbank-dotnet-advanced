using course.Application.DataTransferObjects.Responses;

namespace course.Application.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListDisplayResponse>> GetCourses();
    }
}
