using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.DTOs
{
    public class TeacherAddressDto
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Domain.Teacher.DTOs.TeacherAddressDto ToDomain()
        {
            return new Domain.Teacher.DTOs.TeacherAddressDto()
            {
                City = City,
                ZipCode = ZipCode,
                Street = Street,
                State = State,
                Country = Country
            };
        }
    }
}
