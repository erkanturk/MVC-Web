using _03_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ViewToController.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]//Varsay�lan olarak de�er verilmezse Get yap�s� �al���r.
        public IActionResult Index()//Get G�r�nt�leme
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string ad , string kisiler,bool onay=false)//Optional Parameters
        {
            var k1 = Request.Form["kisiler"];
            var a1 = Request.Form["ad"];
            var o1 = Request.Form["onay"];

            ViewBag.name=a1;
            return View();
        }


    }
}
