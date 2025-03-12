using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edugo.StudentService.Domain
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public Guid Id { get; set; }

        public double Value { get; set; }

        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public required Student Student { get; set; }

        public Guid? DisciplineId { get; set; } // Referência externa não gerenciada aqui
    }
}
