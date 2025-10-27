using _14_Middlewares_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middlewares_1.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            ViewBag.Message="Bu sayfa Hýzlý yüklenir. (0.100ms)";
            return View();
        }
        public async Task<IActionResult> SlowPage()
        {
            await Task.Delay(2000);
            //2 saniye bekletiyoruz.
            ViewBag.Message="Bu sayfa Yavaþ yüklenir. (2000ms)";
            ViewBag.Title="Yavaþ Sayfa";
            return View("Index");
        }
        public IActionResult Privacy()
        {
            ViewBag.Message="Privacy Sayfasý Orta hýzda yüklenir";
            ViewBag.Title="Privacy Sayfasý";
            return View("Index");
        }


    }
}
