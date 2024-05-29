using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get;   set; }
        public UserType userType { get; set; }

        public Student Student { get; set; }
        public int? Student_Id { get; set; }   
        
    }

    public enum Gender
    {
        Male, 
        Female,
        Other
    }
    public enum UserType
    {
        Admin,
        Teeacher,
        Student 
    }
}
