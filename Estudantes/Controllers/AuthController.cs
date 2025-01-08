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

        [HttpGet]
        public IActionResult Login()
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
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Login inválido.");
            return View(loginRequest);
        }
    }
}
