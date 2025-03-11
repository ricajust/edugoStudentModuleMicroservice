using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edugo.StudentService.Domain
{
	public class Student : User
	{
		public DateTime EnrollmentDate { get; set; }

		public ICollection<StudentDiscipline> StudentDisciplines { get; set; }
		public ICollection<Grade> Grades { get; set; }

		// Billing será ignorado por enquanto
	}
}
