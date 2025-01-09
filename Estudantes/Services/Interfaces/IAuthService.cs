using Estudantes.DTOs;

namespace Estudantes.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
