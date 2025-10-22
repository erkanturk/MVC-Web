using _04_ViewData_ViewBag_TempDate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempDate.Controllers
{
    public class HomeController : Controller
    {
        /*Controller dan View'e veri taþýma yöntemleri 
         * ViewBag:Dinamik bir yapýdýr ve herhangi bir türde veri taþýyabilir. Controller'dan view'e veri taþýmak için kullanýlýr.
         * ViewData:Bir sözlük (dictionary) yapýsýdýr ve string anahtar-deðer çiftleri kullanýr. Controller'dan view'e veri taþýmak için kullanýlýr.
         * TempData:Bir istekten diðerine veri taþýmak için kullanýlýr. Genellikle yönlendirme (redirect) iþlemlerinde kullanýlýr.
         * Geçici veri taþýmak için kullanýrýz ve iki sonuç (action,view) arasýnda veri taþýr.
         * Key value yapýsýnda çalýþýr.

         */

        public IActionResult Index()
        {
            ViewBag.ad="Erkan";
            ArrayList liste = new ArrayList();
            liste.Add('A');
            liste.Add(10);
            liste.Add("Merhaba");
            ViewBag.liste = liste;
            ViewBag.sonuc = true;
            //ViewBag dynamic yapýda olduðu için herhangi bir türde veri taþýyabiliriz.

            //viewdata key-value yapýsýnda çalýþýr. veriyi 1 action boyunca tutar.
            ViewData["soyad"]="Türk";

            //TempData key-value yapýsýnda çalýþýr. veriyi 2 action boyunca tutar.
            TempData["cinsiyet"]="Erkek";
            TempData.Keep("cinsiyet"); //TempData verisini korur.
            return View();
        }

        public IActionResult About()
        {
            ViewBag.text=ViewBag.ad;//ViewBag ile veri taþýnamaz.
            //var msg = TempData["cinsiyet"];//TempData ile veri taþýnabilir.
            
            TempData["c"]= TempData["cinsiyet"];//TempData ile veri taþýnabilir.

            return View();
        }

       
    }
}
