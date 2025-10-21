using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {

        //Aksiyon
        //Method=>Geriye IActionResult Döndüren bir method IActionResult geriye bir sonuç sayfasý döndürür.
        public IActionResult Index()
        {
            //Method geriye IActionResult döndürmek zorundad olduðundan geriye bir view döndürüyoruz
            //Bu view =>Views/Home/Index
            return View();
        }

        //Home/About
        public IActionResult About()//sað týk Add View
        {
            return View();
        }

       
    }
}
