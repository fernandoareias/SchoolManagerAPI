using SchoolManager.Services.Teacher.Domain.Teacher.Entities;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CourseService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<Course> GetCourseByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
