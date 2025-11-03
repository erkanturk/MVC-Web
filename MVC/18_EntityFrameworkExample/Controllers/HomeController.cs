using _18_EntityFrameworkExample.Data;
using _18_EntityFrameworkExample.Extensions;
using _18_EntityFrameworkExample.Models;
using _18_EntityFrameworkExample.ViewModels;
using EFCore.BulkExtensions;
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
        public IActionResult QuerySyntax()
        {

            var students = (from s in _context.Students
                            where s.Age>20
                            orderby s.Name
                            select s).ToList();
            return View(students);
        }
        public IActionResult MethodSyntax()
        {
            var students = _context.Students.Where(s => s.Age<18).ToList();
            return View(students);
        }
        public IActionResult Join()
        {
            var studentCourses = (from s in _context.Students
                                  join c in _context.Courses on s.Id equals c.StudentId
                                  select new
                                  {
                                      StudentName = s.Name,
                                      CourseTitle = c.Title
                                  }).ToList();
            return View(studentCourses);
        }
        public IActionResult GetStudentsByDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetStudentsByDepartment(string department)
        {
            var students = new List<Student>();
            try
            {
                students=_context.Students.FromSqlInterpolated($"Exec GetStudentsByDepartment {department}")
                    .ToList();
            }
            catch (Exception)
            {

                students= new List<Student>();
            }
            ViewData["Students"]=students;
            return View();
        }
        public IActionResult GroupByDepartment()
        {
            var groupedStudents = _context.Students
                .GroupBy(s => s.Department)
                .Select(g => new GroupedStudentViewModel()
                {
                    Department=g.Key,
                    Students=g.ToList()
                }).ToList();
            return View(groupedStudents);
        }

        [HttpPost("Transaction")]
        public IActionResult AddStudentsWithTransaction([FromBody] List<Student> students)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Students.AddRange(students);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return StatusCode(500, "Öðrenci eklenirken hata oluþtu");

            }
            return Ok("Öðrenciler baþarýyla eklendi");
        }
        public IActionResult RawSql()
        {
            var students = _context.Students
                .FromSqlRaw("SELECT * FROM Students WHERE Age > {0}", 18)
                .ToList();
            return View("Index", students);
        }
        public IActionResult CustomExtensionMethod()
        {
            var students = _context.Students.ToList();
            var groupedStudents = students.GroupByAgeRange();
            return View(groupedStudents);
        }
        public IActionResult BulkInsert()
        {
            var students = new List<Student>()
            {
                new Student { Name="Ali Veli", Age=22, Department="Matematik" },
                new Student { Name="Ayþe Fatma", Age=19, Department="Fizik" },
            };
            _context.BulkInsert(students);
            return View("Index", students);
        }
    }


}
