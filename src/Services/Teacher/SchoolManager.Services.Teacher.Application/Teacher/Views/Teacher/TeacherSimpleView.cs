using SchoolManager.Services.Teacher.Application.Teacher.Views.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.Views.Teacher
{
    public class TeacherSimpleView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public CourseSimpleView Course { get; set; }

        public TeacherSimpleView(Domain.Teacher.Entities.Teacher teacher, Domain.Teacher.Entities.Course course)
        {
            Id = teacher.Id;
            Name = teacher.Name.ToString();
            Email = teacher.Email.Address;
            Course = new CourseSimpleView(course);
        }
    }
}
