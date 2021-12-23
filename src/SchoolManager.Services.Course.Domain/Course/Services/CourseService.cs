using SchoolManager.Services.Course.Domain.Course.DTOs;
using SchoolManager.Services.Course.Domain.Course.Enum;
using SchoolManager.Services.Course.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Domain.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository _courseRepoistory;
        public CourseService(ICourseRepository courseRepoistory)
        {
            _courseRepoistory = courseRepoistory;
        }

        public async Task<Course.Entity.Course> CreateCourse(CourseCreateDto courseDto)
        {
            var entity = new Course.Entity.Course();
            entity.Name = courseDto.Name;
            entity.Price = courseDto.Price;
            entity.Difficulty = (EDifficulty)courseDto.Difficulty;
            entity.Workload = courseDto.Workload;
            entity.StartDate = courseDto.StartDate;
            entity.EndDate = courseDto.EndDate;

            
            return await _courseRepoistory.Create(entity);

        }

        public async Task<List<Course.Entity.Course>> GetAllCourses()
        {
            return await _courseRepoistory.GetAll();
        }

        public async Task<Course.Entity.Course> GetCourseById(Guid Id)
        {
            return await _courseRepoistory.GetById(Id);
        }

        public async Task<Course.Entity.Course> RemoveCourse(Guid Id)
        {
            var entity = await _courseRepoistory.GetById(Id);
            if (entity == null) return null;
            return await _courseRepoistory.Remove(entity);
        }

        public async Task<Course.Entity.Course> UpdateCourse(CourseUpdateDto courseDto, Guid id)
        {
            var course = await _courseRepoistory.GetById(id);
            if (course == null) return null;

            course.Name = courseDto.Name;
            course.Price = courseDto.Price;
            course.Difficulty = (EDifficulty)courseDto.Difficulty;
            course.Workload = courseDto.Workload;
            course.StartDate = courseDto.StartDate;
            course.EndDate = courseDto.EndDate;


            return await _courseRepoistory.Update(course);
        }
    }
}
