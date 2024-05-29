using DataAccessLayer.Command.DepartmentCommand;
using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.Select(x => new Department
            {
                Department_Id = x.Department_Id,
                Department_Name = x.Department_Name
            }).ToList();
        }
        public async Task AddDepartment(AddDepartment d)
        {
            var newDepartment = new Department
            {
                Department_Name = d.Department_Name
            };
            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveDepartment(int id)
        {
            var result = _context.Departments.FirstOrDefault(e => e.Department_Id == id);
            if (result != null)
            {
                _context.Departments.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateDepartment(Department department)
        {

            var result = _context.Departments.FirstOrDefault(d => d.Department_Id == department.Department_Id);
            if (result != null) 
            {
                result.Department_Name = department.Department_Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Department_Id == id);
        }
    }
}
