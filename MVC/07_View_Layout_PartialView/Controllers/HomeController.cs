using _07_View_Layout_PartialView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _07_View_Layout_PartialView.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
