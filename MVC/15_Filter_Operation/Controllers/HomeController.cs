using _15_Filter_Operation.Filters;
using _15_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Filter_Operation.Controllers
{
    public class HomeController : Controller
    {


        [ServiceFilter(typeof(AccountFilter))]
        public IActionResult Index()
        {
            return RedirectToAction("SpecialAction");
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Privacy()
        {
            return View();
        }
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpecialAction()
        {
            throw new Exception("Bu özel bir hata mesajýdýr.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
