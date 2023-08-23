using AutoMapper;
using course.Entities;

namespace course.Application.DataTransferObjects
{
    public static class DTOConverterExtensions
    {
        public static T ConvertToDto<T>(this Course course, IMapper mapper) where T : class
        {
            return mapper.Map<T>(course);
        }

        public static T ConvertToDto<T>(this IEnumerable<Course> courses, IMapper mapper) where T : class
        {
            return mapper.Map<T>(courses);
        }
    }
}
