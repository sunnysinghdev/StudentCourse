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
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;
        public CourseController(ICourseService service)
        {
            courseService = service;
        }
        
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courseService.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = courseService.Get(id);
            if (course == null)
                return NotFound();
            return course;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            try
            {
                course.StudentCourses = new List<StudentCourse>();
                courseService.Add(course);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Created(course.Id.ToString(), new { Message="Course added successfully!!!"});
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course course)
        {
            var oldcourse = courseService.Get(id);
            if (oldcourse == null)
            {
                return NotFound();
            }
            try
            {
                courseService.Update(id, course);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(new { Message = "Course updated successfully!!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var oldStudent = courseService.Get(id);
            if (oldStudent == null)
            {
                return NotFound();
            }
            try
            {
                courseService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Course deleted successfully!!" });
        }
    }
}
