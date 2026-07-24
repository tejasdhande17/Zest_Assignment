using Microsoft.AspNetCore.Mvc;
using Zest_Project.Models;

namespace Zest_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        // GET
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

        // POST
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (students.Any(s => s.Id == student.Id))
                    return BadRequest("Student ID already exists.");

                students.Add(student);

                return Ok("Student Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                var existing = students.FirstOrDefault(s => s.Id == id);

                if (existing == null)
                    return NotFound("Student Not Found");

                existing.Name = student.Name;
                existing.Age = student.Age;
                existing.Course = student.Course;

                return Ok("Student Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = students.FirstOrDefault(s => s.Id == id);

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