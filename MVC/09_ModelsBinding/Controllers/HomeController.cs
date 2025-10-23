using _09_ModelsBinding.Models;
using _09_ModelsBinding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_ModelsBinding.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult HomePage()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Ahmet",
                Soyad = "Yilmaz",
                Yas = 30
            };
            return View(kisi);
        }

        public IActionResult HomePage2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Mehmet",
                Soyad = "Kara",
                Yas = 25
            };
            Adres adres = new Adres()
            {
                AdresTanim = "Ataturk Cad. No:10",
                Sehir = "Istanbul"
            };
            homePageViewModel viewModel = new homePageViewModel();
            viewModel.KisiNesnesi = kisi;
            viewModel.AdresNesnesi = adres;

            return View(viewModel);
        }

       
    }
}
