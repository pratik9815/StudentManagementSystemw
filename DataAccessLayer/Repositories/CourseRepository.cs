using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
