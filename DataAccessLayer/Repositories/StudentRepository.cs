using Azure;
using DataAccessLayer.Command.StudentCommand;
using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Numerics;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetStudent>> GetAllStudents()
        {
            var studnet =  await _context.Students.AsNoTracking().Select(x => new GetStudent
            {
                Student_Id = x.Student_Id,
                Name = x.Name,
                Address = x.Address,
                Age = x.Age,
                Email = x.Email,
                Gender = x.Gender,
                DOB = x.DOB,
                Phone = x.Phone
                
            }).ToListAsync();
            return studnet;
        }

        public async Task<GetStudent> GetStudentById(int id)
        {
            var student = await _context.Students.AsNoTracking().Where(x => x.Student_Id == id)
                .Select(x => new GetStudent
                {
                    Student_Id = x.Student_Id,
                    Name = x.Name,
                    Address = x.Address,
                    Age = x.Age,
                    Email = x.Email,
                    Gender = x.Gender,
                    DOB = x.DOB,
                    Phone = x.Phone
                }).FirstOrDefaultAsync();
                return student;
        }

        public async Task AddStudent(AddStudent student)
        {
            DateTime today = DateTime.UtcNow;
            var result = new Student
            {
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
                Age = today.Year - student.DOB.Year,
                Phone = student.Phone,
                DOB = student.DOB,

            };
            _context.Students.Add(result);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudent(int id)
        {
            var result = _context.Students.FirstOrDefault(x => x.Student_Id == id);
            if(result != null)
            {
                _context.Students.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateStudent(UpdateStudent student)
        {
            DateTime today = DateTime.UtcNow;
            var result = _context.Students.FirstOrDefault(x => x.Student_Id == student.Student_Id);
            if(result != null)
            {
                result.Name = student.Name;
                result.Email = student.Email;
                result.Address = student.Address;
                result.Phone = student.Phone;
                result.DOB = student.DOB;
                result.Age = today.Year - student.DOB.Year;

                await _context.SaveChangesAsync();
            }
        }

    }
}
