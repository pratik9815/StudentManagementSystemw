using DataAccessLayer.Command.StudentCommand;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<GetStudent>> GetAllStudents();
        Task<GetStudent> GetStudentById(int id);
        Task AddStudent(AddStudent student);    
        Task RemoveStudent(int id);
        Task UpdateStudent(UpdateStudent student);
    }
}
