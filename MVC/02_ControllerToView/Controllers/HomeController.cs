
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3" };
            ViewData["Products"]=products;//listin içinceki veriyi frontent tarafýna yollama iþlemi
            return View();
        }

        public IActionResult Details(int id)
        {
            id=2;
            var product = $"Ürün {id} Detaylarý";
            ViewData["Product"]=product;//Veriyi view dataile view e yollama
            return View();
        }

       
    }
}
