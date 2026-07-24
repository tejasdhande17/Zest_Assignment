using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zest_Project.Models;

namespace Zest_Project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = students.FirstOrDefault(x => x.Id == id);

                if (student == null)
                    return NotFound("Student Not Found");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (students.Any(x => x.Id == student.Id))
                    return BadRequest("Student Id already exists.");

                if (students.Any(x => x.Email == student.Email))
                    return BadRequest("Email already exists.");

                students.Add(student);

                return Ok("Student Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                var existingStudent = students.FirstOrDefault(x => x.Id == id);

                if (existingStudent == null)
                    return NotFound("Student Not Found");

                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Course = student.Course;
                existingStudent.Email = student.Email;

                return Ok("Student Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = students.FirstOrDefault(x => x.Id == id);

                if (student == null)
                    return NotFound("Student Not Found");

                students.Remove(student);

                return Ok("Student Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}