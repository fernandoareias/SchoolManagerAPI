using SchoolManager.Services.Teacher.Domain.Teacher.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Entities
{
    [NotMapped]
    public class Course : Entity
    {
       
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(30, ErrorMessage = "The name should be a maximum of 30 characters.")]
        [MinLength(3, ErrorMessage = "The name should be at least 3 characters long.")]
        public string Name { get;  set; }
        [Required(ErrorMessage = "Price is required!")]
        [Range(1, 9999)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Difficulty is required!")]
        public EDifficulty Difficulty { get;  set; }
        [Required(ErrorMessage = "Workload is required!")]
        public int Workload { get; set; }
        [Required(ErrorMessage = "Start date is required!")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
