﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Course
    {
        public int Course_Id { get; set; }  
        public string Course_Name { get; set; }
        public int Course_Year { get; set; }
        public string Course_Type { get; set; }
        public string Course_Description { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public int Department_Id { get; set; }
        public Department Department { get; set; }

        public int Teacher_Id { get; set; }
        public Teacher Teacher { get; set; }
        
        public ICollection<Grade> Grades { get; set; }

    }
}
