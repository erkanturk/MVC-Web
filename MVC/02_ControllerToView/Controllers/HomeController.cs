
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "�r�n 1", "�r�n 2", "�r�n 3" };
            ViewData["Products"]=products;//listin i�inceki veriyi frontent taraf�na yollama i�lemi
            return View();
        }

        public IActionResult Details(int id)
        {
            id=2;
            var product = $"�r�n {id} Detaylar�";
            ViewData["Product"]=product;//Veriyi view dataile view e yollama
            return View();
        }

       
    }
}
