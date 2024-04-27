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
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Add(Student student);    


    }
}
