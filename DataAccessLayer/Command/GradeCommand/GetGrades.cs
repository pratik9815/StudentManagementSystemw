
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Command.GradeCommand
{
    public class GetGrades
    {
        public int Grade_Id { get; set; }
        public int Student_Grade { get; set; }
    }
    public class GetGrade
    {
        public int Grade_Id { get; set; }
        public int Student_Grade { get; set; }
    }
}
