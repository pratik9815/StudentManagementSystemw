using DataAccessLayer.Command.TeacherCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ITeacherRepository
    {
        IEnumerable<GetTeachers> GetAllTeachers();
        Task<GetTeacher> GetTeacherById(int id);
        Task AddTeacher(AddTeacher teacher);
        Task RemoveTeacher(int id);
        Task UpdateTeacher(UpdateTeacher teacher);
    }
}
