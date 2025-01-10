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
                var city = await _context.Cities.FindAsync(entity.Address.CityId); 
                var state = await _context.States.FindAsync(city?.StateId);
                entity.Address.City = city;  
                entity.Address.City.State = state;
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
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
            return await _context.Students
                .Include(x => x.Address)
                .Include(x => x.Course)
                .Include(x => x.Course.Educationalnstitution)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.Students
               .Include(s => s.Address)  
               .ThenInclude(a => a.City) 
               .Include(s => s.Course)
               .ThenInclude(a => a.Educationalnstitution)
               .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Student entity)
        {
            try
            {
                // Carrega a entidade do banco de dados
                var studentUpdate = await _context.Students
                    .Include(s => s.Course)
                        .ThenInclude(c => c.Educationalnstitution) // Inclui a instituição educacional do curso
                    .Include(s => s.Address)
                        .ThenInclude(a => a.City) // Inclui a cidade do endereço
                    .FirstOrDefaultAsync(s => s.Id == entity.Id);

                if (studentUpdate != null)
                {
                    // Desanexa a instância carregada para evitar conflito
                    _context.Entry(studentUpdate).State = EntityState.Detached;

                    // Atualiza as propriedades de studentUpdate com os valores de entity
                    studentUpdate.Cpf = entity.Cpf;
                    studentUpdate.Name = entity.Name;
                    studentUpdate.Course.Name = entity.Course.Name;
                    studentUpdate.Course.GraduationDate = entity.Course.GraduationDate;

                    // Atualiza o endereço
                    studentUpdate.Address.Description = entity.Address.Description;
                    studentUpdate.Address.CityId = entity.Address.CityId;

                    // Atualiza a instituição educacional, se necessário
                    if (entity.Course.EducationalnstitutionId != studentUpdate.Course.EducationalnstitutionId)
                    {
                        studentUpdate.Course.EducationalnstitutionId = entity.Course.EducationalnstitutionId;
                    }

                    // Marca como modificado e salva
                    _context.Entry(studentUpdate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Trata a exceção adequadamente
                throw new Exception("Erro ao atualizar o estudante", ex);
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

        public async Task<IEnumerable<EducationalInstitution>> GetInstitutionByCityAsync(string cityId)
        {
            return await _context.Institutions.Where(x => x.CityId == cityId).ToListAsync();
        }
    }
}
