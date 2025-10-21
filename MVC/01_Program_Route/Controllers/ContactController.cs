using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
