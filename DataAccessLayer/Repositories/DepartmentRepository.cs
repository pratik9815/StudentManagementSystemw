using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
