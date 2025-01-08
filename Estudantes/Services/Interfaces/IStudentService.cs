using Estudantes.DTOs;
using Estudantes.Models;

namespace Estudantes.Services.Interfaces
{
    public interface IStudentService
    {
        Task <IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(string id);
        Task<Student> AddAsync(StudentDTO student);
        Task UpdateAsync(StudentDTO student);
        Task DeleteAsync(string id);
    }
}
