using Newtonsoft.Json;
using SchoolManager.Services.Teacher.Domain.Teacher.Entities;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Domain.Teacher.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient client;

        public CourseService(HttpClient client)
        {
            this.client = client;
        }        

        public async Task<Course> GetCourseById(Guid id)
        {
            var response = await client.GetAsync($"/api/courses/{id}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseView>(apiContent);
            if (resp.IsSuccess)
            {
                var course = JsonConvert.DeserializeObject<Course>(Convert.ToString(resp.Data));
                course.Id = id;
                return course;
            }
            return new Course();
        }
    }
}
