using course.Entities;
using course.Infrastructure.Repositories;

namespace course.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepository.GetAllAsync();
        }
    }
}
