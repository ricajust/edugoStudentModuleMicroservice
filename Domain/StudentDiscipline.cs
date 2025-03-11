using System;
using System.ComponentModel.DataAnnotations;

namespace Edugo.StudentService.Domain
{
	public class StudentDiscipline
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public Guid StudentId { get; set; }

		public int Absences { get; set; } = 0;

		// DisciplineId para referenciar a disciplina no monólito
		public Guid DisciplineId { get; set; }

		public Student Student { get; set; }
	}
}