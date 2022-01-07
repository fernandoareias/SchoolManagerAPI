using SchoolManager.Services.Teacher.Application.Teacher.DTOs;
using SchoolManager.Services.Teacher.Application.Teacher.Views;
using SchoolManager.Services.Teacher.Application.Teacher.Views.Teacher;
using SchoolManager.Services.Teacher.Domain.Teacher.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.Interfaces
{
    public interface ITeacherAppService
    {
        Task<IResponse> GetById(Guid Id);
        Task<IResponse> GetByCourseId(Guid Id);
        Task<IResponse> Create(Guid IdCourse, TeacherCreateDto teacherDto);
        Task<IResponse> Update(Guid IdTeacher, TeacherUpdateDto teacherDto);
        Task<IResponse> Remove(Guid Id);
    }
}
