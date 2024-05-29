using DataAccessLayer.Command.StudentCommand;
using DataAccessLayer.Model;
using DataAccessLayer.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-all-students")]
        public async Task<ActionResult<IEnumerable<GetStudent>>> GetAllStudent()
        {
            try
            {
                var result = await _unitOfWork.StudentRepository.GetAllStudents();
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching the user data");
            }

        }
        [HttpPost("add-student")]
        public async Task<ActionResult> AddStudent([FromBody] AddStudent student)
        {
            try
            {
                await _unitOfWork.StudentRepository.AddStudent(student);
                _unitOfWork.SaveChanges();
                return Ok("Student added ");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching the user data");
            }
        }
        [HttpDelete("remove-student/{id}")]
        public async Task<ActionResult> RemoveStudent([FromRoute] int id)
        {
            try
            {
                await _unitOfWork.StudentRepository.RemoveStudent(id);
                _unitOfWork.SaveChanges();
                return Ok($"Student with id {id} is removed");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching the user data");
            }

        }
        [HttpPut("update-student/{id}")]
        public async Task<ActionResult> UpdateStudent([FromRoute]int id, UpdateStudent student)
        {
            try
            {
                var result = await _unitOfWork.StudentRepository.GetStudentById(id);
                if(result != null)
                {
                    await _unitOfWork.StudentRepository.UpdateStudent(student);
                    return Ok($"Student with id {id} updated successfully");
                }
                return BadRequest($"Student with id {id} not found");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating the data");
            }
        }
        [HttpGet("get-student-by-id/{id}")]
        public async Task<ActionResult<Student>> GetStudentById([FromRoute]int id)
        {
            try
            {
                var result = await _unitOfWork.StudentRepository.GetStudentById(id);
                if(result != null)
                    return Ok(result);
                return NotFound($"The student with id {id} not found");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There is an error with the server");
            }
        }
    }
}
