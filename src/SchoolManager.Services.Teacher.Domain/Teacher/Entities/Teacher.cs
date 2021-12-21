using SchoolManager.Services.Teacher.Domain.Teacher.VOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Entities
{
    [Table("Teachers")]
    public class Teacher : Entity
    {
        
        [Required(ErrorMessage = "Name is required!")]
        public virtual Name Name { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public virtual Email Email { get; set; }
        public virtual Address Adresses { get; set; }


        public Guid CourseId { get; set; }

    }
}
