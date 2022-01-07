using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Domain.Course.DTOs
{
    public class CourseUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Difficulty { get; set; }
        public int Workload { get;  set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
