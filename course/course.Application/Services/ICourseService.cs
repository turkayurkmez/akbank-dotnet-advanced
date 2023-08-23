using course.Application.DataTransferObjects.Requests;
using course.Application.DataTransferObjects.Responses;

namespace course.Application.Services
{
    public interface ICourseService
    {
        Task<CourseListDisplayResponse> GetCourseAsync(int id);
        Task<IEnumerable<CourseListDisplayResponse>> GetCourses();
        Task<IEnumerable<CourseListDisplayResponse>> GetCoursesByTitle(string title);

        Task<int> CreateNewCourse(CreateNewCourseRequest courseRequest);
        Task UpdateCourse(UpdateCourseRequest courseRequest);
        Task DeleteCourse(int id);

        Task<bool> IsExists(int id);

    }
}
