using Elasticsearch.Models.VOs;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elasticsearch.Models.Teacher
{
    
    public class Teacher : Entity.Entity
    {
        public Teacher()
        {

        }

        public Teacher(Elasticsearch.Models.VOs.Name name, Email email, Address adress, Guid courseId)
        {
            Name = name;
            Email = email;
            Address = adress;
            CourseId = courseId;
        }

        [Required(ErrorMessage = "Name is required!")]
        [Text(Name = "teacher_name")]
        public virtual Elasticsearch.Models.VOs.Name Name { get; set; }
        [Text(Name = "teacher_email")]
        [Required(ErrorMessage = "Email is required!")]
        public virtual Email Email { get; set; }
        [Text(Name = "teacher_address")]
        public virtual Address Address { get; set; }

        [Text(Name = "teacher_courseId")]
        public Guid CourseId { get; set; }

    }
}
