using Estudantes.DTOs;
using Estudantes.Models;

namespace Estudantes.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
        Task DeleteAsync(string id);
    }
}
