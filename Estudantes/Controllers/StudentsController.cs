using Estudantes.DTOs;
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

        public IActionResult Create()
        {
            return View();
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
    }
}
