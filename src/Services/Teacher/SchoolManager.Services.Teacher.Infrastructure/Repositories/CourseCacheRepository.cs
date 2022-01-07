using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SchoolManager.Services.Teacher.Domain.Teacher.Entities;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Infrastructure.Repositories
{
    public class CourseCacheRepository : ICourseCacheRepository
    {
        private readonly IDistributedCache _cache;

        public CourseCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<Course> Add(Course course)
        {
            try
            {
                var serialize = JsonConvert.SerializeObject(course);

                var encoded = System.Text.Encoding.UTF8.GetBytes(serialize);

                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _cache.SetAsync(course.Id.ToString(), encoded, options);

                return course;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Course> GetById(Guid id)
        {
            var course = await _cache.GetAsync(id.ToString());
            if (course == null) return null;

            string serialized = System.Text.Encoding.UTF8.GetString(course);

            var courseDeseralized = JsonConvert.DeserializeObject<Course>(serialized);
            if (courseDeseralized == null) return null;

            return courseDeseralized;
        }
    }
}
