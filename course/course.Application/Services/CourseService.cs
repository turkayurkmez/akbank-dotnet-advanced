﻿using AutoMapper;
using course.Application.DataTransferObjects;
using course.Application.DataTransferObjects.Requests;
using course.Application.DataTransferObjects.Responses;
using course.Entities;
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

        public async Task<int> CreateNewCourse(CreateNewCourseRequest courseRequest)
        {
            var course = _mapper.Map<Course>(courseRequest);
            await _courseRepository.CreateNewAsync(course);
            return course.Id;
        }

        public async Task DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);

        }

        public async Task<CourseListDisplayResponse> GetCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            var response = course.ConvertToDto<CourseListDisplayResponse>(_mapper);
            return response;
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

            // var response = _mapper.Map<IEnumerable<CourseListDisplayResponse>>(courses);

            var response = courses.ConvertToDto<IEnumerable<CourseListDisplayResponse>>(_mapper);

            return response;
        }

        public async Task<IEnumerable<CourseListDisplayResponse>> GetCoursesByTitle(string title)
        {
            var courses = await _courseRepository.SearchCoursesByName(title);
            return _mapper.Map<IEnumerable<CourseListDisplayResponse>>(courses);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _courseRepository.IsExists(id);
        }

        public async Task UpdateCourse(UpdateCourseRequest courseRequest)
        {
            var course = _mapper.Map<Course>(courseRequest);
            await _courseRepository.UpdateAsync(course);

        }
    }
}
