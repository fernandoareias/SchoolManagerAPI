using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Services.Course.Application;
using SchoolManager.Services.Course.Application.Course.DTOs;
using SchoolManager.Services.Course.Application.Course.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.API.Controllers
{

    [ApiController]
    [Route("api/courses")]
    public class CourseController : Controller
    {
        private readonly ICourseAppService _courseAppService;

        public CourseController(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

       // [Authorize]
        [HttpGet]
        public async Task<IResponse> GetAllCourse()
        {
            return await _courseAppService.GetAllCourses();
        }

        //[Authorize]
        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _courseAppService.GetCourseById(Id);
        }

        [HttpPost]
        public async Task<IResponse> CreateCourse([FromBody] CourseCreateDto courseDto)
        {
            return await _courseAppService.CreateCourse(courseDto);
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<IResponse> UpdateCourse([FromBody] CourseUpdateDto courseDto, Guid id)
        {
            return await _courseAppService.UpdateCourse(courseDto, id);
        }

        // [Authorize]
        [HttpDelete]
        public async Task<IResponse> DeleteCourse(Guid Id)
        {
            return await _courseAppService.RemoveCourse(Id);
        }

    }
}
