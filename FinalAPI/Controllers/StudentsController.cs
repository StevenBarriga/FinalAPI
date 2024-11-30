using FinalAPI.DAL.Entities;
using FinalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Client;

namespace FinalAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAsync()
        {
            var students = await _studentService.GetStudentsAsync();

            if (students == null || !students.Any() ) 
            {
                return NotFound();
            }
            return Ok(students);
        }



        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpPost, ActionName("Create")]
        [Route ("Create")]
        public async Task<ActionResult<Student>> CreateStudentAsync(Student student)
        {
            try
            {
                var newStudent = await _studentService.CreateStudentAsync(student);
                if (newStudent == null) return NotFound();
                return Ok(newStudent);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", student.Name));

                return Conflict(ex.Message);
            }
        }



        [HttpPut, ActionName ("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Student>> UpdateStudentAsync(Student student)
        {
            try
            {
                var editedStudent = await _studentService.UpdateStudentAsync(student);
                if (editedStudent == null) return NotFound();
                return Ok(editedStudent);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", student.Name));

                return Conflict(ex.Message);
            }
        }



        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(Guid id)
        {
            if (id == null) return BadRequest(); 

            var deletedStudent = await _studentService.DeleteStudentAsync(id);
            if (deletedStudent == null) return NotFound();
            return Ok(deletedStudent);
            
        }

    }
}
