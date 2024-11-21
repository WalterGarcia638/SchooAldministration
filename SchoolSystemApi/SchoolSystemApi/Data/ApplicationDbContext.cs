using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolSystemApi.Model;

namespace SchoolSystemApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set;}
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Grade> Grade { get; set; } 
        public DbSet<StudentGradeDetail> StudentGradeDetail { get; set; }
     

    }
}