using SchoolManager.Services.Teacher.Domain.Teacher.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher.Entities.Teacher> GetById(Guid Id);
        Task<List<Teacher.Entities.Teacher>> GetAll();
        Task<List<Teacher.Entities.Teacher>> GetByCourseId(Guid Id);
        Task<Teacher.Entities.Teacher> Create(Guid IdCourse , TeacherCreateDto teacherDto);
        Task<Teacher.Entities.Teacher> Update(Guid IdCourse, Guid IdTeacher, TeacherUpdateDto teacherDto);
        Task<Teacher.Entities.Teacher> Remove(Guid Id);
        Task<List<Teacher.Entities.Teacher>> RemoveByCourseId(Guid IdCourse);

    }
}
