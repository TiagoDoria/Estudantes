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

    }
}
