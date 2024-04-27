using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Student
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<Grade> Grades { get; set; }

    }
}
