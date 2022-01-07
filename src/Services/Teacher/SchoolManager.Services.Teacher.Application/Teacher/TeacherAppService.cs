using SchoolManager.Services.Teacher.Application.Responses;
using SchoolManager.Services.Teacher.Application.Teacher.DTOs;
using SchoolManager.Services.Teacher.Application.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Application.Teacher.Views;
using SchoolManager.Services.Teacher.Application.Teacher.Views.Teacher;
using SchoolManager.Services.Teacher.Domain.Teacher.Entities;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher
{
    public class TeacherAppService : ITeacherAppService
    {

        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseServicce;
        private readonly ICourseCacheRepository _courseCacheRepository;

        public TeacherAppService(
            ITeacherService teacherService,
            ICourseService courseServicce, 
            ICourseCacheRepository courseCacheRepository
            )
        {
            _teacherService = teacherService;
            _courseServicce = courseServicce;
            _courseCacheRepository = courseCacheRepository;
        }



        public async Task<IResponse> Create(Guid IdCourse, TeacherCreateDto teacherDto)
        {

            var course = await _courseCacheRepository.GetById(IdCourse);

            if(course == null)
            {
                course = await _courseServicce.GetCourseById(IdCourse);
            }

            if (course == null)
                return new ResponseView(false, "Course not found", null);


            var teacher = await _teacherService.Create(IdCourse, teacherDto.ToDomain());

            if (teacher == null)
                return new ResponseView(false, "Teacher not found", null);

            var view = new TeacherView(teacher, course);

            return new ResponseView(true, "Teacher create", view);
        }

        public async Task<IResponse> GetByCourseId(Guid Id)
        {

            var teachers = await _teacherService.GetByCourseId(Id);
            if (teachers == null)
            {
                return new ResponseView(false, "Teacher not found", null);
            }

            var course = await _courseCacheRepository.GetById(Id);

            if (course == null)
            {
                course = await _courseServicce.GetCourseById(Id);
            }

            if (course == null)
                return new ResponseView(false, "Course not found", null);


            var views = teachers.Select(t => new TeacherSimpleView(t, course)).ToList();

            return new ResponseView(true, "Has teachers", views);
        }

        public async Task<IResponse> GetById(Guid Id)
        {
            
            var teacher = await _teacherService.GetById(Id);
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            var course = await _courseCacheRepository.GetById(Id);

            if (course == null)
            {
                course = await _courseServicce.GetCourseById(Id);
            }

            if (course == null)
                return new ResponseView(false, "Course not found", null);


            var view = new TeacherView(teacher, course);

            return new ResponseView(true, "Has teacher", view);
        }

        public async Task<IResponse> Remove(Guid Id)
        {
            var teacher = await _teacherService.Remove(Id);
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher not found", null);
            }

            var course = await _courseCacheRepository.GetById(Id);

            if (course == null)
            {
                course = await _courseServicce.GetCourseById(Id);
            }

            if (course == null)
                return new ResponseView(false, "Course not found", null);


            var view = new TeacherView(teacher, course);

            return new ResponseView(true, "Teacher removed", view);
        }

        public async Task<IResponse> Update(Guid IdTeacher, TeacherUpdateDto teacherDto)
        {
            var teacher = await _teacherService.Update(IdTeacher, teacherDto.ToDomain());
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher not found", null);
            }

            var course = await _courseCacheRepository.GetById(teacher.CourseId);

            if (course == null)
            {
                course = await _courseServicce.GetCourseById(teacher.CourseId);
            }

            if (course == null)
                return new ResponseView(false, "Course not found", null);


            var view = new TeacherView(teacher, course);

            return new ResponseView(true, "Teacher update", view);
        }
    }
}
