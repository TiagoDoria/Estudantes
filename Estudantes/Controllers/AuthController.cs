using Estudantes.DTOs;
using Estudantes.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estudantes.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequest);
            }

            var response = await _authService.Login(loginRequest);

            if (response != null && !string.IsNullOrEmpty(response.Token))
            {
                // Salvar dados no TempData
                TempData["Token"] = response.Token;
                TempData["UserName"] = response.User.Name;
                TempData["UserEmail"] = response.User.Email;

                // Redireciona para o método Index do HomeController
                return RedirectToAction("Index", "Students");
            }

            ModelState.AddModelError(string.Empty, "Login inválido.");
            return RedirectToAction("Index", "Auth");

        }

        public IActionResult Register()
        {
            return View(new RegistrationRequestDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.Register(registrationRequestDTO);

                if (result == true)
                {
                    return RedirectToAction("Index", "Auth");
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao registrar o usuário. Tente novamente.");
                }
            }

            return View(registrationRequestDTO);
        }
    }
}
