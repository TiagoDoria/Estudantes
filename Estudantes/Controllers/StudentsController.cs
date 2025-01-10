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

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
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
        public async Task<IActionResult> Create([FromForm] StudentDTO studentDto)
        {
            await _studentService.AddAsync(studentDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(); 
            }

            var stateId = student.Address.City.StateId;


            var states = await _studentService.GetAllStatesAsync();
            var cities = await _studentService.GetCitiesByStateAsync(stateId);
            var institutions = await _studentService.GetInstitutionByCityAsync(student.Address.CityId);


            ViewBag.States = states;
            ViewBag.Cities = cities;
            ViewBag.Institutions = institutions;

            return View(student); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] StudentDTO studentDto)
        {
            try
            {
                await _studentService.UpdateAsync(studentDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Update));
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteAsync(id); 
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
