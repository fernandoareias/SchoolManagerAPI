using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Interfaces
{
    public interface ICourseService
    {
        Task<Domain.Teacher.Entities.Course> GetCourseByName(string name);
    }
}
