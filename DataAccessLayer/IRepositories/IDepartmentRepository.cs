using DataAccessLayer.Command.DepartmentCommand;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Task AddDepartment(AddDepartment department);
        Task RemoveDepartment(int id);
        Task UpdateDepartment(Department department);
        Task<Department> GetDepartment(int id);
    }
}
