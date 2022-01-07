using SchoolManager.Services.Course.Application.Course.Interfaces;
using SchoolManager.Services.Course.Application.Responses;
using SchoolManager.Services.Course.Application.Course.DTOs;
using SchoolManager.Services.Course.Application.Course.Views;
using SchoolManager.Services.Course.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Application.Course
{
    public class CourseAppService : ICourseAppService
    {
        private readonly ICourseService _courseService;
        public CourseAppService(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IResponse> CreateCourse(CourseCreateDto courseDto)
        {
            try
            {
                var course = await _courseService.CreateCourse(courseDto.ToDomain());

                if (course == null)
                {
                    return new ResponseView(false, "Not found", null);
                }

                return new ResponseView(true, "Success", new CourseView(course));
            }
            catch (Exception ex)
            {
                return new ResponseView(false, ex.Message, null);
            }
        }

        public async Task<IResponse> GetAllCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCourses();

                if (courses == null && courses.Any() == false)
                {
                    return new ResponseView(false, "Not found", null);
                }

                return new ResponseView(true, "Success", courses.Select(c => new CourseListView(c)).ToList());
            }
            catch (Exception ex)
            {
                return new ResponseView(false, ex.Message, null);
            }
        }

        public async Task<IResponse> GetCourseById(Guid Id)
        {
            try
            {
                var course = await _courseService.GetCourseById(Id);

                if (course == null)
                {
                    return new ResponseView(false, "Not found", null);
                }

                return new ResponseView(true, "Success", new CourseView(course));
            }
            catch (Exception ex)
            {
                return new ResponseView(false, ex.Message, null);
            }
        }

        public async Task<IResponse> RemoveCourse(Guid Id)
        {
            try
            {
                var course = await _courseService.RemoveCourse(Id);

                return new ResponseView(true, "Success", course);
            }
            catch (Exception ex)
            {
                return new ResponseView(false, ex.Message, null);
            }
        }

        public async Task<IResponse> UpdateCourse(CourseUpdateDto courseDto, Guid id)
        {
            try
            {
                var course = await _courseService.UpdateCourse(courseDto.ToDomain(), id);

                if (course == null)
                {
                    return new ResponseView(false, "Not found", null);
                }

                return new ResponseView(true, "Success", new CourseView(course));
            }
            catch (Exception ex)
            {
                return new ResponseView(false, ex.Message, null);
            }
        }
    }
}
