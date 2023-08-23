using AutoMapper;
using course.Application.DataTransferObjects.Requests;
using course.Application.DataTransferObjects.Responses;
using course.Entities;

namespace course.Application.MapProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseListDisplayResponse>();
            CreateMap<CreateNewCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();


        }
    }
}
