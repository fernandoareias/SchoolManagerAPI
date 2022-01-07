using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher.Entities.Teacher>> GetAll();
        Task<Teacher.Entities.Teacher> GetById(Guid Id);
        Task<List<Domain.Teacher.Entities.Teacher>> GetByCourseId(Guid Id);
        Task<Teacher.Entities.Teacher> Create(Teacher.Entities.Teacher teacher);
        Task<Teacher.Entities.Teacher> Update(Teacher.Entities.Teacher teacher);
        Task<Domain.Teacher.Entities.Teacher> Remove(Teacher.Entities.Teacher teacher);
        Task<List<Domain.Teacher.Entities.Teacher>> RemoveByCourseId(Guid IdCourse);
    }
}
