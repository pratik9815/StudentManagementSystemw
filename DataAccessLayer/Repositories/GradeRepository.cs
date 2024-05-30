using DataAccessLayer.Command.GradeCommand;
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

        public IEnumerable<GetGrades> GetAllGrades()
        {
            throw new NotImplementedException();
        }

        public Task<GetGrade> GetGradeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
