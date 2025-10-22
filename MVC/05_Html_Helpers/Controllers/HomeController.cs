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
            User user = new User();//Modelden nesne olu�turuldu.instance �rneklem
            user.CountryList = GetCountries();//Dropdown i�in Country listesi dolduruldu.
            user.Name = "Erkan";

            return View(user);//Model nesnesi View'e g�nderildi.
        }
        [HttpPost]
        public IActionResult Submit(User user)
        {
            var test = ModelState.IsValid;//Model do�rulama kontrol� yap�ld�.
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
                new SelectListItem { Value = "TR", Text = "T�rkiye" },//Value:arka planda tutulacak de�er Text:kullan�c�ya g�sterilecek de�er
                new SelectListItem { Value = "US", Text = "United States" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "CA", Text = "Canada" },
                new SelectListItem { Value = "AU", Text = "Australia" }
            };
        }

    }
}
