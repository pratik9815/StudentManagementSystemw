using DataAccessLayer.Command.TeacherCommand;
using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTeacher(AddTeacher teacher)
        {
            var newTeacher = new Teacher
            {
                Teacher_Name = teacher.Teacher_Name,
                Teacher_Email = teacher.Teacher_Email
            };
            _context.Teachers.Add(newTeacher);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GetTeachers> GetAllTeachers()
        {
            var result = _context.Teachers.AsNoTracking().Select(x => new GetTeachers
            {
                Teacher_Id = x.Teacher_Id,
                Teacher_Email = x.Teacher_Email,
                Teacher_Name = x.Teacher_Name,
            });
            return result;
        }

        public async Task<GetTeacher> GetTeacherById(int id)
        {
            return await _context.Teachers.Where(x => x.Teacher_Id == id).Select(x => new GetTeacher
            {
                Teacher_Id = x.Teacher_Id,
                Teacher_Email = x.Teacher_Email,
                Teacher_Name = x.Teacher_Name,
            }).FirstOrDefaultAsync();
        }

        public async Task RemoveTeacher(int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.Teacher_Id == id);
            if (result != null)
            {
                _context.Teachers.Remove(result);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateTeacher(UpdateTeacher teacher)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.Teacher_Id == teacher.Teacher_Id);
            if(result != null)
            {
                result.Teacher_Email = teacher.Teacher_Email;
                result.Teacher_Name = teacher.Teacher_Name;

                await _context.SaveChangesAsync();
            }
        }
    }
}
