using course.Entities;
using course.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace course.Infrastructure.Repositories
{
    public class EFCourseRepository : ICourseRepository
    {
        private readonly CourseDbContext courseDbContext;

        public EFCourseRepository(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public async Task CreateNewAsync(Course entity)
        {
            await courseDbContext.Courses.AddAsync(entity);
            await courseDbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var course = courseDbContext.Courses.SingleOrDefault(c => c.Id == id);
            courseDbContext.Courses.Remove(course);
            await courseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await courseDbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await courseDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await courseDbContext.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> SearchCoursesByName(string courseName)
        {
            return await courseDbContext.Courses.Where(c => c.Title.Contains(courseName)).ToListAsync();

        }

        public async Task UpdateAsync(Course entity)
        {
            courseDbContext.Courses.Update(entity);
            await courseDbContext.SaveChangesAsync();


        }
    }
}
