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
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var result =  await _unitOfWork.StudentRepository.GetAll();
            return Ok(result);
        }
        [HttpPost("add-student")]
        public async Task<ActionResult> Add([FromBody] Student student)
        {
            await _unitOfWork.StudentRepository.Add(student);   
            _unitOfWork.SaveChanges();
            return Ok($"Student added with Id : {student.Student_Id}");
        }
    }
}
