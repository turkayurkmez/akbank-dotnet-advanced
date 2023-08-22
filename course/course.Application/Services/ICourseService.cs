using course.Entities;

namespace course.Application.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
    }
}
