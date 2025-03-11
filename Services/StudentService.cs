using Edugo.StudentService.Domain;
using Edugo.StudentService.DTOs;
using Edugo.StudentService.Repositories;

namespace Edugo.StudentService.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                EnrollmentDate = s.EnrollmentDate
            });
        }

        public async Task<StudentDTO?> GetByIdAsync(Guid id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                EnrollmentDate = student.EnrollmentDate
            };
        }

        public async Task<StudentDTO> CreateAsync(StudentDTO dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = dto.Name!,
                Email = dto.Email!,
                Password = dto.Password!,
                Role = "Student",
                EnrollmentDate = dto.EnrollmentDate
            };

            await _repository.AddAsync(student);

            dto.Id = student.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            await _repository.DeleteAsync(student);
            return true;
        }
    }
}
