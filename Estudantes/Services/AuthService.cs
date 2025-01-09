using Estudantes.Data;
using Estudantes.DTOs;
using Estudantes.Models;
using Estudantes.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Estudantes.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AuthContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || !isValid)
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDTO userDTO = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };

            LoginResponseDTO responseDTO = new LoginResponseDTO()
            {
                User = userDTO,
                Token = token
            };

            return responseDTO;
        }

        public async Task<bool> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            bool status = true;
            User user = new()
            {
                UserName = registrationRequestDTO.Email,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                Name = registrationRequestDTO.Name,
            };

            try
            {
                await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            return false;
        }    
    }
}
