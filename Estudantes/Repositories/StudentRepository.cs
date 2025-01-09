using Estudantes.Data;
using Estudantes.DTOs;
using Estudantes.Models;
using Estudantes.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Estudantes.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.Students.FindAsync(id);
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task UpdateAsync(Student entity)
        {
            try
            {
                _context.Students.UpdateRange(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesByStateAsync(string stateId)
        {
            return await _context.Cities.Where(x => x.StateId == stateId).ToListAsync();
        }
    }
}
