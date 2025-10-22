using _05_Html_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _05_Html_Helpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            User user = new User();//Modelden nesne oluþturuldu.instance örneklem
            user.CountryList = GetCountries();//Dropdown için Country listesi dolduruldu.
            user.Name = "Erkan";

            return View(user);//Model nesnesi View'e gönderildi.
        }
        [HttpPost]
        public IActionResult Submit(User user)
        {
            var test = ModelState.IsValid;//Model doðrulama kontrolü yapýldý.
            if (ModelState.IsValid)
            {
                ViewBag.Message=$"Name: {user.Name} Age: {user.Age} Gender: {user.Gender} Country: {user.Country}";
                return View("Result");
            }
            return View("Index");
        }
        public IActionResult Result()
        {
            return View();
        }

        public IEnumerable<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "TR", Text = "Türkiye" },//Value:arka planda tutulacak deðer Text:kullanýcýya gösterilecek deðer
                new SelectListItem { Value = "US", Text = "United States" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "CA", Text = "Canada" },
                new SelectListItem { Value = "AU", Text = "Australia" }
            };
        }

    }
}
