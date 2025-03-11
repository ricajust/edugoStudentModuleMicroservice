using System.ComponentModel.DataAnnotations.Schema;

namespace Edugo.StudentService.Domain
{
    [Table("Students")]
    public class Student : User
    {
        public DateTime EnrollmentDate { get; set; }

        // Navigation Properties
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<StudentDiscipline> StudentDisciplines { get; set; } = new List<StudentDiscipline>();
    }
}
