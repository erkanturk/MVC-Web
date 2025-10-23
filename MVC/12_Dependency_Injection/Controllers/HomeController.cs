using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMyService _myService;
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }
        public IActionResult Index()
        {
            List<Student> students = _myService.GetStudents();
            return View(students);
        }

      
    }
}
