using Edugo.StudentService.Domain;

namespace Edugo.StudentService.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task AddAsync(Student student);
        Task DeleteAsync(Student student);
        Task<Student?> GetByEmailAsync(string email);
    }
}
