using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Teacher.Views
{
    public class TeacherAddressView
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public TeacherAddressView(Domain.Teacher.Entities.Teacher teacher)
        {
            City = teacher.Adresses.City;
            ZipCode = teacher.Adresses.ZipCode;
            Street = teacher.Adresses.Street;
            State = teacher.Adresses.State;
            Country = teacher.Adresses.Country;
        }
    }
}
