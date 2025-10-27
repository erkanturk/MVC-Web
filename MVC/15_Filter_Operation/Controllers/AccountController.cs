using Microsoft.AspNetCore.Mvc;

namespace _15_Filter_Operation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
