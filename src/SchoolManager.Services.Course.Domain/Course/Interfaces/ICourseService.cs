using SchoolManager.Services.Course.Domain.Course.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Domain.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course.Entity.Course>> GetAllCourses();
        Task<Course.Entity.Course> GetCourseById(Guid Id);
        Task<Course.Entity.Course> CreateCourse(CourseCreateDto courseDto);
        Task<Course.Entity.Course> UpdateCourse(CourseUpdateDto courseDto, Guid id);
        Task<Course.Entity.Course> RemoveCourse(Guid Id);
    }
}
