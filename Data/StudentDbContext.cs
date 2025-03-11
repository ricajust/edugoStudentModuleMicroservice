using Edugo.StudentService.Domain;
using Microsoft.EntityFrameworkCore;

namespace Edugo.StudentService.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentDiscipline> StudentDisciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().UseTpcMappingStrategy(); // TPC: Table-per-Concrete-Type

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<StudentDiscipline>().ToTable("StudentDisciplines");
        }
    }
}
