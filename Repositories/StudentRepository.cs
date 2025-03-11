using Edugo.StudentService.Data;
using Edugo.StudentService.Domain;
using Microsoft.EntityFrameworkCore;

namespace Edugo.StudentService.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() => await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(Guid id) => await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }
    }
}
