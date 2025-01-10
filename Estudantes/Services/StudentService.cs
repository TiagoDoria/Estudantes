using AutoMapper;
using Estudantes.DTOs;
using Estudantes.Models;
using Estudantes.Repositories.Interface;
using Estudantes.Services.Interfaces;

namespace Estudantes.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Student> AddAsync(StudentDTO studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);
            student.Id = Guid.NewGuid().ToString();
            try
            {
                return await _studentRepository.AddAsync(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<StudentDTO>>(students);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar os estudantes: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(StudentDTO studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);

            try
            {
                await _studentRepository.UpdateAsync(student);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o estudante: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                {
                    throw new Exception("Estudante não encontrado.");
                }

                await _studentRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir o estudante: {ex.Message}", ex);
            }
        }

        public async Task<StudentDTO> GetByIdAsync(string id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);

                if (student == null)
                {
                    throw new Exception("Estudante não encontrado.");
                }

                return _mapper.Map<StudentDTO>(student);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar o estudante com ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<CityDTO>> GetCitiesByStateAsync(string stateId)
        {
            try
            {
                var cities = await _studentRepository.GetCitiesByStateAsync(stateId);

                if (cities == null)
                {
                    throw new Exception("Cidade não encontrado.");
                }

                return _mapper.Map<IEnumerable<CityDTO>>(cities);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar cidades com stateID {stateId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<EducationalInstitutionDTO>> GetInstitutionByCityAsync(string cityId)
        {
            try
            {
                var inst = await _studentRepository.GetInstitutionByCityAsync(cityId);

                if (inst == null)
                {
                    throw new Exception("Instituição não encontrado.");
                }

                return _mapper.Map<IEnumerable<EducationalInstitutionDTO>>(inst);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar instituições com cityID {cityId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<StateDTO>> GetAllStatesAsync()
        {
            try
            {
                var states = await _studentRepository.GetAllStatesAsync();

                return _mapper.Map<IEnumerable<StateDTO>>(states);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar os estados: {ex.Message}", ex);
            }
        }

    }
}
