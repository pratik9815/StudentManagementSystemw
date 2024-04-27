using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Student>().HasKey(s => s.Student_Id);
            modelBuilder.Entity<Course>().HasKey(s => s.Course_Id);
            modelBuilder.Entity<Department>().HasKey(d => d.Department_Id);
            modelBuilder.Entity<Teacher>().HasKey(d => d.Teacher_Id);
            modelBuilder.Entity<Grade>().HasKey(g => g.Grade_Id);

            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(s => new { s.Student_Id , s.Course_Id});
            });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.Student_Id);

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.Course_Id);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(d => d.Department_Id);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.Teacher_Id);


            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.Student_Id);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.Course_Id);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
