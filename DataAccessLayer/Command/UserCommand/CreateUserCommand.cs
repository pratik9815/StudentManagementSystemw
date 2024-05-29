using DataAccessLayer.Model.User;

namespace DataAccessLayer.Command.UserCommand
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public UserType userType { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }    

    }
}
