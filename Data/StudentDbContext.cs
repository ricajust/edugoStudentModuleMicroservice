using System;
using Edugo.StudentService.Domain;
using Microsoft.EntityFrameworkCore;
namespace Edugo.StudentService.Data;

public class StudentDbContext : DbContext
{
	public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

	public DbSet<Student> Students { get; set; }
	public DbSet<Grade> Grades { get; set; }
	public DbSet<StudentDiscipline> StudentDisciplines { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Se precisar de configuração extra:
		modelBuilder.Entity<Student>()
			.HasMany(s => s.Grades)
			.WithOne(g => g.Student)
			.HasForeignKey(g => g.StudentId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Student>()
			.HasMany(s => s.StudentDisciplines)
			.WithOne(sd => sd.Student)
			.HasForeignKey(sd => sd.StudentId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}