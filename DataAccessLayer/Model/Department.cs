using DataAccessLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Department
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }

        public ICollection<DepartmentCourse> DepartmentCourses { get; set; }
        public ICollection<Course> Courses { get; set; }

    }

}
