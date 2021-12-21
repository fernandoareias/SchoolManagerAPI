using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.VOs
{
    [Owned]
    
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private Name()
        {

        }

        [Required(ErrorMessage = "First name is required!")]
        [MinLength(3, ErrorMessage = "The first name should be at least 3 characters long.")]
        [MaxLength(30, ErrorMessage = "The first name should be a maximum of 35 characters.")]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3, ErrorMessage = "The last name should be at least 3 characters long.")]
        [MaxLength(30, ErrorMessage = "The last name should be a maximum of 30 characters.")]
        [Column("LastName")]
        public string LastName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
