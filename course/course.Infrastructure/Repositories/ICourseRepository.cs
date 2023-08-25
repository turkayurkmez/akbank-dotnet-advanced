using course.Entities;

namespace course.Infrastructure.Repositories
{
    public interface ICourseRepository : IRepositoryAsync<Course>
    {
        Task<IEnumerable<Course>> SearchCoursesByName(string courseName);



    }
}
