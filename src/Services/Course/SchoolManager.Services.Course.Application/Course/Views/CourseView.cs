using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Application.Course.Views
{
    public class CourseView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Difficulty { get; set; }
        public int Workload { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public CourseView(Domain.Course.Entity.Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
            this.Price = course.Price;
            this.Difficulty = (int)course.Difficulty;
            this.Workload = course.Workload;
            this.StartDate = course.StartDate;
            this.EndDate = course.EndDate;
        }
    }
}
