using AutoMapper;
using course.Application.DataTransferObjects.Responses;
using course.Infrastructure.Repositories;

namespace course.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseListDisplayResponse>> GetCourses()
        {
            var courses = await _courseRepository.GetAllAsync();

            //Mapping: Bir objedeki verileri başka bir objeye atamak
            //var response = courses.Select(course => new CourseListDisplayResponse
            //{
            //    CategoryId = course.CategoryId,
            //    Description = course.Description,
            //    Duration = course.Duration,
            //    ImageUrl = course.ImageUrl,
            //    Id = course.Id,
            //    StartDate = course.StartDate,
            //    Title = course.Title
            //});

            // TODO 1.1: Bu kısmı extension metot yap:

            var response = _mapper.Map<IEnumerable<CourseListDisplayResponse>>(courses);

            return response;
        }
    }
}
