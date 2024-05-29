using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;
        private IGradeRepository _gradeRepository;
        private IDepartmentRepository _departmentRepository;
        private ITeacherRepository _teacherRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new StudentRepository(_context);
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                return _courseRepository = _courseRepository ?? new CourseRepository(_context);
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);
            }
        }

        public IGradeRepository GradeRepository
        {
            get
            {
                return _gradeRepository = _gradeRepository ?? new GradeRepository(_context);
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                return _teacherRepository = _teacherRepository ?? new TeacherRepository(_context);
            }
        }

        public  void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
