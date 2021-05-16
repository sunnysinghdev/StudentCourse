//Local
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class SampleData
    {
        public static void InitData(AppDbContext dbContext)
        {
            dbContext.Students.Add(
                new Student()
                {
                    Id = 1,
                    FirstName = "Neena",
                    LastName = "Gupta",
                    DOB = new DateTime(1991, 1, 7),
                    ContactNumber = 989812341234
                });
            dbContext.Students.Add(
               new Student()
               {
                   Id = 2,
                   FirstName = "Ramesh",
                   LastName = "Kumar",
                   DOB = new DateTime(1991, 2, 8),
                   ContactNumber = 989812340000
               });
            dbContext.Courses.Add(new Course { Id = 100, Name = "Oracle", Description="This Oracle Course" });//,
            dbContext.Courses.Add(new Course { Id = 200, Name = "Java", Description = "This Java Course" });//,
            dbContext.Courses.Add(new Course { Id = 300, Name = "PHP", Description = "This PHP Course" });//,

            dbContext.StudentCourses.Add(new StudentCourse { StudentId = 1, CourseId = 100 });
            dbContext.StudentCourses.Add(new StudentCourse { StudentId = 2, CourseId = 200 });
            dbContext.StudentCourses.Add(new StudentCourse { StudentId = 2, CourseId = 300 });

            dbContext.SaveChanges();
        }
    }
}
