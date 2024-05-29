using DataAccessLayer.Command.DepartmentCommand;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet("get-departments")]
        public IActionResult GetDepartments()
        {
            try
            {
                var department = _departmentRepository.GetDepartments();
                return Ok(department);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

        }
        [HttpPost("add-department")]
        public async Task<ActionResult> AddDepartment(AddDepartment department)
        {
            try
            {
                if (department == null)
                    return BadRequest();
                await _departmentRepository.AddDepartment(department);
                return Ok("department created successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpDelete("remove-department/{id}")]
        public async Task<ActionResult> RemoveDepartment([FromRoute]int id)
        {
            try
            {
                await _departmentRepository.RemoveDepartment(id);
                return Ok("Department removed successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpPut("update-department/{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, Department department)
        {
            try
            {
                if (id == department.Department_Id)
                    return BadRequest("DepartmentId mismatch");

                var departToUpdate = await _departmentRepository.GetDepartment(id);
                if (departToUpdate == null)
                    return NotFound("The department you are trying to update does not exist.");

                await _departmentRepository.UpdateDepartment(department);

                return Ok("Department update success");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

        }
    }
}
