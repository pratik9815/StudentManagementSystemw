using DataAccessLayer.Command.CourseCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICourseRepository
    {
        IEnumerable<GetCourses> GetAllCourse();
        Task<GetCourse> GetCourseById(int id);
        Task AddCourse(AddCourse course);
        Task DeleteCourse(int id);
        Task UpdateCourse(UpdateCourse course);
    }
}
