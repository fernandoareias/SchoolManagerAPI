using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.DTOs
{
    public class TeacherCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public TeacherAddressDto Address { get; set; }

        public Domain.Teacher.DTOs.TeacherCreateDto ToDomain()
        {
            return new Domain.Teacher.DTOs.TeacherCreateDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Address = Address.ToDomain()
            };
        }
    }
}
