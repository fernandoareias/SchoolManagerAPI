using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace SchoolManager.Services.Course.Tests
{
    public class CourseTest
    {
        private readonly IList<ValidationResult> _courseValid;
        private readonly IList<ValidationResult> _courseInvalid;

        public CourseTest()
        {
            var course = new Domain.Course.Entity.Course();
            course.Name = "English";
            course.Price = 190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = 1300;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)2;

            _courseValid = ValidateModel(course);

            var invalidCourse = new Domain.Course.Entity.Course();
            _courseInvalid = ValidateModel(invalidCourse);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }


        [Fact]
        public void ShouldReturnWhenIsValid()
        {
            Assert.DoesNotContain(_courseValid, c => string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenIsInvalid()
        {
            Assert.Contains(_courseInvalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenNameIsInvalid()
        {

            var course = new Domain.Course.Entity.Course();
            course.Name = "A";
            course.Price = 190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = 1300;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)2;

            var invalid = ValidateModel(course);

            Assert.Contains(invalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenPriceIsNegative()
        {

            var course = new Domain.Course.Entity.Course();
            course.Name = "English";
            course.Price = -190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = 1300;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)2;

            var invalid = ValidateModel(course);

            Assert.Contains(invalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenWorkloadIsInvalid()
        {

            var course = new Domain.Course.Entity.Course();
            course.Name = "English";
            course.Price = 190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = 5001;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)2;

            var invalid = ValidateModel(course);

            Assert.Contains(invalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenWorkloadIsNegative()
        {

            var course = new Domain.Course.Entity.Course();
            course.Name = "English";
            course.Price = 190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = -1;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)2;

            var invalid = ValidateModel(course);

            Assert.Contains(invalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }

        [Fact]
        public void ShouldNotReturnWhenDifficultyIsInvalid()
        {

            var course = new Domain.Course.Entity.Course();
            course.Name = "English";
            course.Price = 190;
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(5);
            course.Workload = 500;
            course.Difficulty = (Domain.Course.Enum.EDifficulty)10;

            var invalid = ValidateModel(course);

            Assert.Contains(invalid, c => !string.IsNullOrEmpty(c.ErrorMessage));
        }
    }
}
