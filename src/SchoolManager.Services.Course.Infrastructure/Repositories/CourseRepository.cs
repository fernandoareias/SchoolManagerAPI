using Microsoft.EntityFrameworkCore;
using SchoolManager.Services.Course.Domain.Interfaces;
using SchoolManager.Services.Course.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Course.Entity.Course> Create(Domain.Course.Entity.Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return course;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<Domain.Course.Entity.Course>> GetAll()
        {
            try
            {
                return await _context.Courses.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Domain.Course.Entity.Course> GetById(Guid Id)
        {
            try
            {
                return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Domain.Course.Entity.Course> Remove(Domain.Course.Entity.Course course)
        {
            try
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return course;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Domain.Course.Entity.Course> Update(Domain.Course.Entity.Course course)
        {
            try
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return course;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
