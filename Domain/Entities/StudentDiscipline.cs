using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edugo.StudentService.Domain
{
    [Table("StudentDisciplines")]
    public class StudentDiscipline
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public Guid? DisciplineId { get; set; } // Não há tabela Discipline aqui

        public int Absences { get; set; } = 0;
    }
}
