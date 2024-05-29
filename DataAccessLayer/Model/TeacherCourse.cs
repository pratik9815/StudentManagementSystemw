using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TeacherCourse
    {
        public int TeacherCourse_Id { get; set; }
        public int Teacher_Id { get; set; }
        public Teacher Teacher { get; set; }
        public int Course_Id { get; set; }
        public Course Course { get; set; }
    }
}
