using Microsoft.EntityFrameworkCore;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Teacher.Entities.Teacher>> GetByCourseId(Guid Id)
        {
            try
            {
                return await _context.Teachers.AsNoTracking().Where(t => t.CourseId.Equals(Id)).ToListAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Teacher.Domain.Teacher.Entities.Teacher> Create(Teacher.Domain.Teacher.Entities.Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
                return teacher;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<Teacher.Domain.Teacher.Entities.Teacher>> GetAll()
        {
            try
            {
                return await _context.Teachers.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Teacher.Domain.Teacher.Entities.Teacher> GetById(Guid Id)
        {
            try
            {
                return await _context.Teachers.AsNoTracking().FirstOrDefaultAsync(t => t.Id.Equals(Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Teacher.Domain.Teacher.Entities.Teacher> Remove(Teacher.Domain.Teacher.Entities.Teacher teacher)
        {
            try
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return teacher;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<Domain.Teacher.Entities.Teacher>> RemoveByCourseId(Guid IdCourse)
        {
            try
            {
                var teachers = await _context.Teachers.Where(t => t.CourseId.Equals(IdCourse)).ToListAsync();

                if (teachers == null || !teachers.Any()) 
                    return null;

                _context.Teachers.RemoveRange(teachers);

                return teachers;
            }   
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Teacher.Domain.Teacher.Entities.Teacher> Update(Teacher.Domain.Teacher.Entities.Teacher teacher)
        {
            try
            {
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return teacher;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
