using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {

        //Aksiyon
        //Method=>Geriye IActionResult D�nd�ren bir method IActionResult geriye bir sonu� sayfas� d�nd�r�r.
        public IActionResult Index()
        {
            //Method geriye IActionResult d�nd�rmek zorundad oldu�undan geriye bir view d�nd�r�yoruz
            //Bu view =>Views/Home/Index
            return View();
        }

        //Home/About
        public IActionResult About()//sa� t�k Add View
        {
            return View();
        }

       
    }
}
