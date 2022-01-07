using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Application.Course.Views
{
    public class CourseListView
    {
        public CourseListView(Domain.Course.Entity.Course course)
        {
            Id = course.Id;
            Name = course.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
