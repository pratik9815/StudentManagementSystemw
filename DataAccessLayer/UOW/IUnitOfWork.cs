using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UOW
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IGradeRepository GradeRepository { get; }
        ITeacherRepository TeacherRepository { get; }

        void SaveChanges();
    }
}
