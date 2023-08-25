using course.Entities;

namespace course.Infrastructure.Repositories
{
    public class FakeCourseRepository : ICourseRepository
    {
        public Task CreateNewAsync(Course entity)
        {
            throw new NotImplementedException();
        }



        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = new List<Course>()
           {
               new(){ Id=1, CategoryId=1, Description="TEST", Duration=1, Title="Test"},
               new(){ Id=2, CategoryId=1, Description="TEST", Duration=1, Title="Test"},
               new(){ Id=3, CategoryId=1, Description="TEST", Duration=1, Title="Test"},

           };

            return Task.FromResult(courses.AsEnumerable());
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> SearchCoursesByName(string courseName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
