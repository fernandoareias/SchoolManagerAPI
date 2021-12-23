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

        public TeacherAppService(
            ITeacherService teacherService,
            ICourseService courseServicce
        )
        {
            _teacherService = teacherService;
            _courseServicce = courseServicce;
        }

        public async Task<IResponse> GetAll()
        {
            //GetCourse
            //var course = _courseServicce.GetCourseByName;
            var course = new Course();
            var teachers = await _teacherService.GetAll();
            if (teachers == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            var views = teachers.Select(t => new TeacherSimpleView(t, course)).ToList();



            return new ResponseView(true, "Teacher update", views);
        }

        public async Task<IResponse> Create(Guid IdCourse, TeacherCreateDto teacherDto)
        {
            //GetCourse
            //var course = _courseServicce.GetCourseByName;
            var course = new Course();
            var teacher = await _teacherService.Create(IdCourse, teacherDto.ToDomain());
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            return new ResponseView(true, "Teacher update", teacher);
        }

        public async Task<IResponse> GetByCourseId(Guid Id)
        {
            //GetCourse
            //var course = _courseServicce.GetCourseByName;
            var course = new Course();
            var teachers = await _teacherService.GetByCourseId(Id);
            if (teachers == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            var views = teachers.Select(t => new TeacherSimpleView(t, course)).ToList();

          

            return new ResponseView(true, "Teacher update", views);
        }

        public async Task<IResponse> GetById(Guid Id)
        {
            //GetCourse
            //var course = _courseServicce.GetCourseByName;
            var course = new Course();
            var teacher = await _teacherService.GetById(Id);
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            return new ResponseView(true, "Teacher update", teacher);
        }

        public async Task<IResponse> Remove(Guid Id)
        {
            var teacher = await _teacherService.Remove(Id);
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            return new ResponseView(true, "Teacher update", teacher);
        }

        public async Task<IResponse> Update(Guid IdCourse, Guid IdTeacher, TeacherUpdateDto teacherDto)
        {
            var teacher = await _teacherService.Update(IdCourse, IdTeacher, teacherDto.ToDomain());
            if (teacher == null)
            {
                return new ResponseView(false, "Teacher nop", null);
            }

            return new ResponseView(true, "Teacher update", teacher);
        }
    }
}
