using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.User
{
    public class DepartmentCourse
    {
        public int DepartmentCourse_Id { get; set; }
        public int Department_Id { get; set; }
        public Department Department { get; set; }
        public int Course_Id { get; set; }
        public Course Course { get; set; }
    }
}
