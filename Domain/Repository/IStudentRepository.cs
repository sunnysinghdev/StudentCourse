using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        //bool Exists(Student student);
        //Student Get(int id);
        //IEnumerable<Student> GetAll();
        //void Add(Student student);
        //void Remove(Student student);
        //int Save();
        ICollection<StudentCourseDto> GetCourses();
        void AddCourse(StudentCourse studentCourse);
    }
}
