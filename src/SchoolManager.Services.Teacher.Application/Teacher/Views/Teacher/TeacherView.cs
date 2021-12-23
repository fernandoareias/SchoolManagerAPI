using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.Views
{
    public class TeacherView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public TeacherAddressView Address { get; set; }


        public CourseView Course { get; set; }

        public TeacherView(Domain.Teacher.Entities.Teacher teacher, Domain.Teacher.Entities.Course course)
        {
            Id = teacher.Id;
            Name = teacher.Name.ToString();
            Address = new TeacherAddressView(teacher);
            Course = new CourseView(course);
        }
    }
}
