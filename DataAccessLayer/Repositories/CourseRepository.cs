using DataAccessLayer.Command.CourseCommand;
using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCourse(AddCourse course)
        {
            var newCourse = new Course
            {
                Course_Name = course.Course_Name,
                Course_Description = course.Course_Description,
                Course_Type = course.Course_Type,
                Course_Year = course.Course_Year,
            };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(x => x.Course_Id == id);
            if(result != null)
            {
                _context.Courses.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<GetCourses> GetAllCourse()
        {
            return _context.Courses.Select(x => new GetCourses
            {
                Course_Id = x.Course_Id,
                Course_Name = x.Course_Name,
                Course_Description = x.Course_Description,
                Course_Year = x.Course_Year,
                Course_Type = x.Course_Type,
            }).ToList();
        }

        public async Task<GetCourse> GetCourseById(int id)
        {
            return await _context.Courses.Where(x => x.Course_Id == id)
                        .Select(x => new GetCourse
                        {
                            Course_Id = x.Course_Id,
                            Course_Name = x.Course_Name,
                            Course_Description = x.Course_Description,
                            Course_Year = x.Course_Year,
                            Course_Type = x.Course_Type,
                        }).FirstOrDefaultAsync();
        }
        public async Task UpdateCourse(UpdateCourse course)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(x => x.Course_Id == course.Course_Id);
            if(result != null)
            {
                result.Course_Name = course.Course_Name;
                result.Course_Description = course.Course_Description;
                result.Course_Year = course.Course_Year;
                result.Course_Type = course.Course_Type;
                
                await _context.SaveChangesAsync();
            }

        }  
    }
}
