using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course.Entity.Course>> GetAll();
        Task<Course.Entity.Course> GetById(Guid Id);
        Task<Course.Entity.Course> Create(Course.Entity.Course course);
        Task<Course.Entity.Course> Update(Course.Entity.Course course);
        Task<Course.Entity.Course> Remove(Course.Entity.Course course);
    }
}
