using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.Views.Course
{
    public class CourseSimpleView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public CourseSimpleView(Domain.Teacher.Entities.Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
      
        }
    }
}
