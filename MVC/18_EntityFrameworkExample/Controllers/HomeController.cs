using _18_EntityFrameworkExample.Data;
using _18_EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _18_EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context=context;
        }


        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            if (student==null)
            {
                return NotFound();
            }

            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//CSRF saldýrýlarýný önlemek için
        public IActionResult Create([Bind("Id,Name,Age,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student==null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age,Department")] Student student)
        {
            if (id!=student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student==null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Overload method imza tipleri farklý olmalýdýr
        //Delete int id alýyorsa ayný parametreyi  kullanarak ayný isimde method oluþturulamaz
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student!=null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id==id);
        }

    }
}
