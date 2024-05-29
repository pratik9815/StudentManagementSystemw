using DataAccessLayer.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Model.User;
using DataAccessLayer.Model;
using DataAccessLayer.UOW;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Command.UserCommand;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public ApplicationUserController(ApplicationDbContext context,
                                         UserManager<ApplicationUser> userManager,
                                         SignInManager<ApplicationUser> signInManager,
                                         IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("add-user")]
        public async Task<ActionResult> AddUser([FromBody] CreateUserCommand user)
        {
            DateTime today = DateTime.UtcNow;
            var student = new Student
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
                Gender = user.Gender,
                DOB = user.DOB,
                Age = today.Year - user.DOB.Year,
                Email = user.Email
            };

            if (user.userType == UserType.Student)
            {
                _context.Students.Add(student); 
                await _context.SaveChangesAsync();
            }

            var newUser = new ApplicationUser
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
                Age = today.Year - user.DOB.Year,
                Gender = user.Gender,
                DOB = user.DOB,
                UserName = user.UserName,
                Email = user.Email,
                Student_Id = user.userType is UserType.Student ? student.Student_Id : null
            };
            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok(result);
        }

        [HttpPost("authenticate-user")]
        public async Task<IActionResult> AuthenticateResult(AuthenticateRequest request )
        {
            var identityUser = await _userManager.FindByNameAsync(request.UserName);
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if(!result.Succeeded)
                return Unauthorized();

            TokenGenerateDetail tokenDetails = GetTokenDetails(identityUser);
            string token = TokenGeneratorService.GenerateToken(tokenDetails, _configuration);


            return Ok(token);
        }

        private TokenGenerateDetail GetTokenDetails(ApplicationUser user)
        {
            return new TokenGenerateDetail
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserType = user.userType,
                Address = user.Address,
                Phone = user.Phone,
                FullName = user.Name,
                Email = user.Email,
                //UniqueKey = uniqueKey,
                StudentId = user.Student_Id
            };
        }

    }

    public class TokenGenerateDetail
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public int? StudentId { get; set; }
        public UserType UserType { get; set; }
        //public string UniqueKey { get; set; }
    }
}

