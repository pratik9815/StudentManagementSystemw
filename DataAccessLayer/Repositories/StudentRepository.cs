using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.Where(x => x.Student_Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Add(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
