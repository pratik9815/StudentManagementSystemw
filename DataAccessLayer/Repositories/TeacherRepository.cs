using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
