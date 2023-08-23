using AutoMapper;
using course.Application.DataTransferObjects.Responses;
using course.Entities;

namespace course.Application.MapProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseListDisplayResponse>();

        }
    }
}
