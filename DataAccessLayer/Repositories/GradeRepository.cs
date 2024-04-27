using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
