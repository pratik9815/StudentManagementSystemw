using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Grade
    {
        public int Grade_Id { get; set; }

        public int Student_Grade {  get; set; }

        public Course Course { get; set; }
        public int Course_Id { get; set; }  


        public Student Student { get; set; }
        public int Student_Id { get; set; }

    }
}
