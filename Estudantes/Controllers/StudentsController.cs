using Estudantes.DTOs;
using Estudantes.Models;
using Estudantes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estudantes.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            var states = await _studentService.GetAllStatesAsync();
            ViewBag.States = states;
            var student = new StudentDTO
            {
                Course = new CourseDTO()
                {
                    Educationalnstitution = new EducationalInstitutionDTO()
                }
            };
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] StudentDTO studentDto)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddAsync(studentDto);  
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);  
        }

        public IActionResult Update(string id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(); 
            }

            var studentDto = new StudentDTO(); // MAPEAMENTO

            return View(studentDto); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] StudentDTO studentDto)
        {
            if (ModelState.IsValid)
            {           
                _studentService.UpdateAsync(studentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);
        }

        public IActionResult Delete(string id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(); 
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteAsync(id); 
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesByState(string stateId)
        {
            var cities = await _studentService.GetCitiesByStateAsync(stateId);
            return Json(cities);
        }

        [HttpGet]
        public async Task<IActionResult> GetInstitutionByCity(string cityId)
        {
            var inst = await _studentService.GetInstitutionByCityAsync(cityId);
            return Json(inst);
        }
    }
}
