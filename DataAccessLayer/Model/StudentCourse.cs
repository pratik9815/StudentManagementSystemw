using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class StudentCourse
    {
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        public int Course_Id { get; set; }
        public Course Course { get; set;}

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    }
}
