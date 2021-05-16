using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCourse(StudentCourse studentCourse)
        {
            _dbContext.StudentCourses.Add(studentCourse);
            Save();
        }

        public ICollection<StudentCourseDto> GetCourses()
        {
            var query = from student in _dbContext.Students
                        join studentCourse in _dbContext.StudentCourses on student.Id equals studentCourse.StudentId
                        join course in _dbContext.Courses on studentCourse.CourseId equals course.Id
                        select new StudentCourseDto
                        {
                            StudentId = student.Id,
                            CourseId = course.Id,
                            StudentName = student.FirstName + " " + student.LastName,
                            CourseName = course.Name
                        };
            return query.ToList();

        }

        //public void Add(Student student)
        //{
        //    _dbContext.Students.Add(student);
        //}

        //public bool Exists(Student student)
        //{
        //    var st = _dbContext.Students.Where(st =>
        //                   st.FirstName.ToLower() == student.FirstName.ToLower() &&
        //                   st.LastName.ToLower() == student.LastName.ToLower()).FirstOrDefault();
        //    if (st == null)
        //        return false;
        //    return true;
        //}

        //public Student Get(int id)
        //{
        //    return _dbContext.Students.Find(id);
        //}

        //public IEnumerable<Student> GetAll()
        //{
        //    return _dbContext.Students;//.Include(c=> c.Courses);
        //}

        //public void Remove(Student student)
        //{
        //    _dbContext.Students.Remove(student);
        //}

        //public int Save()
        //{
        //    return _dbContext.SaveChanges();
        //}
    }
}
