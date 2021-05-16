using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface ICourseService
    {
        Course Get(int id);
        IEnumerable<Course> GetAll();
        void Add(Course course);
        void Update(int id, Course course);
        void Delete(int id);
    }
    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;
        public CourseService(ICourseRepository repository)
        {
            courseRepository = repository;
        }

        public void Add(Course course)
        {


            if (courseRepository.Exists(c => c.Name.ToLower().Replace(" ", "") == course.Name.ToLower().Replace(" ", "")))
            {
                throw new Exception("Course already exits with requested name.");
            }
            courseRepository.Add(course);
            courseRepository.Save();

        }

        public void Delete(int id)
        {
            courseRepository.Remove(courseRepository.Get(id));
        }

        public Course Get(int id)
        {
            return courseRepository.Get(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return courseRepository.Get();
        }

        public void Update(int id, Course course)
        {
            var oldcourse = courseRepository.Get(id);
            oldcourse.Name = course.Name ?? oldcourse.Name;
            oldcourse.Description = course.Description ?? oldcourse.Description;

            courseRepository.Save();
        }
    }
}
