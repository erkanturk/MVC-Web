using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Details(int id)
        {
            id = 5;
            ViewData["blogId"]=id;
            return View();
        }
    }
}
