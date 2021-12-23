using SchoolManager.Services.Teacher.Domain.Teacher.DTOs;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Domain.Teacher.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teacher.Entities.Teacher>> GetAll()
        {
            return await _teacherRepository.GetAll();
        }
        
        public async Task<Entities.Teacher> Create(Guid IdCourse, TeacherCreateDto teacherDto)
        {

            var name = new Name(teacherDto.FirstName, teacherDto.LastName);
            var email = new Email(teacherDto.Email);
            var address = new Address(teacherDto.Address.City, teacherDto.Address.ZipCode, teacherDto.Address.Street, teacherDto.Address.State, teacherDto.Address.Country);

            var teacher = new Entities.Teacher(name, email, address, IdCourse);
            
            return await _teacherRepository.Create(teacher);
        }

        public async Task<List<Entities.Teacher>> GetByCourseId(Guid Id)
        {
            return await _teacherRepository.GetByCourseId(Id);
        }

        public async Task<Entities.Teacher> GetById(Guid Id)
        {
            return await _teacherRepository.GetById(Id);
        }

        public async Task<Entities.Teacher> Remove(Guid Id)
        {
            var teacher = await _teacherRepository.GetById(Id);
            if (teacher == null) return null;
            return await _teacherRepository.Remove(teacher);
        }

        public async Task<List<Entities.Teacher>> RemoveByCourseId(Guid IdCourse)
        {
            return await _teacherRepository.RemoveByCourseId(IdCourse);
        }

        public async Task<Entities.Teacher> Update(Guid IdCourse, Guid IdTeacher, TeacherUpdateDto teacherDto)
        {
            var teacher = await _teacherRepository.GetById(IdTeacher);

            if (teacher == null) return null;

            var name = new Name(teacherDto.FirstName, teacherDto.LastName);
            var email = new Email(teacherDto.Email);
            var address = new Address(teacherDto.Address.City, teacherDto.Address.ZipCode, teacherDto.Address.Street, teacherDto.Address.State, teacherDto.Address.Country);

            teacher.Name = name;
            teacher.Email = email;
            teacher.Adresses = address;

            return await _teacherRepository.Update(teacher);
        }
    }
}
