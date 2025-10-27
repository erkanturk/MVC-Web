using _14_Middlewares.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middlewares.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            var middlewareMessage = HttpContext.Items["MiddlewareMessage"]?.ToString();
            //?. operatörü null kontrolü yapar.
            //HttpContext.Items ile middleware'den gelen veriyi alýyoruz.
            ViewBag.MiddlewareInfo= middlewareMessage; //ViewBag ile View'a veri gönderiyoruz.

            return View();
        }

     
    }
}
