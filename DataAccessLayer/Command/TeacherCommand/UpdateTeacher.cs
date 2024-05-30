using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Command.TeacherCommand
{
    public class UpdateTeacher
    {
        public int Teacher_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Email { get; set; }
    }
}
