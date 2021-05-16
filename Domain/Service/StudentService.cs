using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IStudentService
    {
        Student Get(int id);
        void Add(Student student);
        void Update(int id, Student student);
        void Delete(int id);
        ICollection<Student> Get();
        ICollection<StudentCourseDto> GetCourses();
        void Add(StudentCourse studentCourse);
    }
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepo;
        public StudentService(IStudentRepository repo)
        {
            studentRepo = repo;
        }




        public Student Get(int id)
        {
            return studentRepo.Get(id);
        }

        public ICollection<Student> Get()
        {
            return studentRepo.Get().ToList();
        }
        public void Add(Student student)
        {
            if (studentRepo.Exists(st =>
                           st.FirstName.ToLower() == student.FirstName.ToLower() &&
                           st.LastName.ToLower() == student.LastName.ToLower()))
            {
                throw new Exception("Student already exits with requested name.");
            }
            studentRepo.Add(student);
            studentRepo.Save();
        }
        public ICollection<StudentCourseDto> GetCourses()
        {
            return studentRepo.GetCourses();
        }
        public void Update(int id, Student student)
        {
            var oldStudent = studentRepo.Get(id);
            oldStudent.FirstName = student.FirstName ?? oldStudent.FirstName;
            oldStudent.LastName = student.LastName ?? oldStudent.LastName;
            oldStudent.DOB = student.DOB ?? oldStudent.DOB;
            oldStudent.ContactNumber = student.ContactNumber ?? oldStudent.ContactNumber;

            studentRepo.Save();
        }
        public void Delete(int id)
        {
            studentRepo.Remove(studentRepo.Get(id));
        }




        public void Add(StudentCourse studentCourse)
        {
            studentRepo.AddCourse(studentCourse);
        }
    }
}
