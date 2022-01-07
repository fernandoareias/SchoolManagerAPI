using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Application.Course.DTOs
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Difficulty { get; set; }
        public int Workload { get;  set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Domain.Course.DTOs.CourseCreateDto ToDomain()
        {
            return new Domain.Course.DTOs.CourseCreateDto()
            {
                Name = Name,
                Price = Price,
                Difficulty = Difficulty,
                Workload = Workload,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
