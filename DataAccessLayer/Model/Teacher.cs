using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Teacher
    {
        public int Teacher_Id { get; set; } 
        public string Teacher_Name { get; set; }
        public string Teacher_Email { get; set; }
        public int Department_Id { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
