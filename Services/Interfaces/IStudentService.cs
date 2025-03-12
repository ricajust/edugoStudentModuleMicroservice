using Edugo.StudentService.DTOs;

namespace Edugo.StudentService.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO?> GetByIdAsync(Guid id);
        Task<StudentDTO> CreateAsync(StudentDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
