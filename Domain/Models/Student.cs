using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        //[Key]

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? DOB { get; set; }
        public long? ContactNumber { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }


    }
}
