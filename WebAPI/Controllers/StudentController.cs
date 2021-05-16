using Domain.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet("Course")]
        public ICollection<StudentCourseDto> GetCourses()
        {
            return _studentService.GetCourses();
        }
        [HttpPost("Course")]
        public IActionResult AddCourse([FromBody] StudentCourse studentCourse)
        {
            try
            {
                _studentService.Add(studentCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Student/Courses", studentCourse);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                student.StudentCourses = new List<StudentCourse>();
                _studentService.Add(student);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Created(student.Id.ToString(), new {Message="Student added successfully"});
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var oldStudent = _studentService.Get(id);
            if (oldStudent == null)
            {
                return NotFound();
            }
            try
            {
                _studentService.Update(id, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Student updated successfully!!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var oldStudent = _studentService.Get(id);
            if (oldStudent == null)
            {
                return NotFound();
            }
            try
            {
                _studentService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Student deleted successfully!!" });
        }
    }
}
