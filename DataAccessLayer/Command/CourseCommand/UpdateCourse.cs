using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Command.CourseCommand
{
    public class UpdateCourse
    {
        public int Course_Id { get; set; }
        public string Course_Name { get; set; }
        public int Course_Year { get; set; }
        public CourseType Course_Type { get; set; }
        public string Course_Description { get; set; }
        public int Department_Id { get; set; } 
    }
}
