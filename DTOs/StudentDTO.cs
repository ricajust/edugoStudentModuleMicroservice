namespace Edugo.StudentService.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Opcional para cadastro
        public DateTime EnrollmentDate { get; set; }
    }
}
