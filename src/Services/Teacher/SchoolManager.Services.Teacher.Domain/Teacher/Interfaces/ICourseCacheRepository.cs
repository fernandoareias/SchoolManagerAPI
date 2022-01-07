using SchoolManager.Services.Teacher.Domain.Teacher.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Interfaces
{
    public interface ICourseCacheRepository
    {
        Task<Course> GetById(Guid id);
        Task<Course> Add(Course course);

    }
}
