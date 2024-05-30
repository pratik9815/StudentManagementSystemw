using DataAccessLayer.Command.CourseCommand;
using DataAccessLayer.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all-courses")]
        public ActionResult<IEnumerable<GetCourses>> GetAllCourses()
        {
            try
            {
                var result = _unitOfWork.CourseRepository.GetAllCourse();
                if(result != null)
                    return Ok(result);
                return NotFound("No record available");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<GetCourse>> GetCourseById([FromRoute]int id)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetCourseById(id);
                if(result != null)
                    return Ok(result);
                return NotFound($"Sorry the course with id {id} is not found ");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse([FromBody]AddCourse course)
        {
            try
            {
                if(course != null)
                {
                    await _unitOfWork.CourseRepository.AddCourse(course);
                    return Ok("The course is added");
                }
                return BadRequest("Something went wrong");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpDelete("remove-course/{id}")]
        public async Task<IActionResult> RemoveCourse([FromRoute]int id)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetCourseById(id);
                if(result != null)
                {
                    await _unitOfWork.CourseRepository.DeleteCourse(id);
                    return Ok($"The course with {id} is successfully removed");
                }
                return NotFound($"The request course with id {id} is not found");                    
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPut("update-course/{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute]int id, [FromBody]UpdateCourse course)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetCourseById(id);
                if (result != null)
                {
                    await _unitOfWork.CourseRepository.UpdateCourse(course);
                    return Ok($"The course with id {id} is updated");
                }
                return NotFound($"The course with id {id} is not found");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
