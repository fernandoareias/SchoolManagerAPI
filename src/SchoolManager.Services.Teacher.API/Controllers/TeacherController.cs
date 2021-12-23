using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Services.Teacher.Application;
using SchoolManager.Services.Teacher.Application.Teacher.DTOs;
using SchoolManager.Services.Teacher.Application.Teacher.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.API.Controllers
{

    [ApiController]
    [Route("api/courses")]
    public class TeacherController : Controller
    {
        private readonly ITeacherAppService _teacherAppService;

        public TeacherController(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

       // [Authorize]
        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _teacherAppService.GetAll();
            if (result.Data == null) return NotFound(result);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("teachers/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _teacherAppService.GetById(Id);
            if (result.Data == null) return NotFound(result);
            return Ok(result);
        }

        //[Authorize]
        [HttpPost("{idCourse}/teachers")]
        public async Task<IActionResult> CreateTeacher(Guid idCourse, [FromBody] TeacherCreateDto teacherDto)
        {
            var result = await _teacherAppService.Create(idCourse, teacherDto);
            if (result.Data == null) return NotFound(result);
            return Ok(result);
        }

        // [Authorize]
        [HttpPut("{idCourse}/teachers/{idTeacher}")]
        public async Task<IActionResult> UpdateTeacher(Guid idCourse, Guid idTeacher, [FromBody] TeacherUpdateDto teacherDto)
        {
            var result = await _teacherAppService.Update(idCourse, idTeacher, teacherDto);
            if (result.Data == null) return NotFound(result);
            return Ok(result);
        }

        // [Authorize]
        [HttpDelete("teachers/{Id}")]
        public async Task<IActionResult> DeleteTeacher(Guid Id)
        {
            var result = await _teacherAppService.Remove(Id);
            if (result.Data == null) return NotFound(result);
            return Ok(result);
        }

    }
}
