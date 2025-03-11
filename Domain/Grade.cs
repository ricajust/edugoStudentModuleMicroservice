using System;
using System.ComponentModel.DataAnnotations;

namespace Edugo.StudentService.Domain
{
	public class Grade
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public double Value { get; set; }

		[Required]
		public Guid StudentId { get; set; }

		public Guid DisciplineId { get; set; }

		public Student Student { get; set; }
	}
}
