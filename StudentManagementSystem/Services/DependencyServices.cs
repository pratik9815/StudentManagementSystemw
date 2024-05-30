using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.UOW;

namespace StudentManagementSystem.Services
{
    public class DependencyServices 
    {
        private readonly IServiceCollection _services;

        public DependencyServices(IServiceCollection services)
        {
            _services = services;
        }
        public static IServiceCollection DependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
