using SchoolManager.Services.Course.Application.Course.DTOs;
using SchoolManager.Services.Course.Application.Course.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Application.Course.Interfaces
{
    public interface ICourseAppService
    {
        Task<IResponse> GetAllCourses();
        Task<IResponse> GetCourseById(Guid Id);
        Task<IResponse> CreateCourse(CourseCreateDto courseDto);
        Task<IResponse> UpdateCourse(CourseUpdateDto courseDto);
        Task<IResponse> RemoveCourse(Guid Id);
    }
}
