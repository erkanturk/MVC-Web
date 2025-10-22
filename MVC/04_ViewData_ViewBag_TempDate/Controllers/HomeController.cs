using _04_ViewData_ViewBag_TempDate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempDate.Controllers
{
    public class HomeController : Controller
    {
        /*Controller dan View'e veri ta��ma y�ntemleri 
         * ViewBag:Dinamik bir yap�d�r ve herhangi bir t�rde veri ta��yabilir. Controller'dan view'e veri ta��mak i�in kullan�l�r.
         * ViewData:Bir s�zl�k (dictionary) yap�s�d�r ve string anahtar-de�er �iftleri kullan�r. Controller'dan view'e veri ta��mak i�in kullan�l�r.
         * TempData:Bir istekten di�erine veri ta��mak i�in kullan�l�r. Genellikle y�nlendirme (redirect) i�lemlerinde kullan�l�r.
         * Ge�ici veri ta��mak i�in kullan�r�z ve iki sonu� (action,view) aras�nda veri ta��r.
         * Key value yap�s�nda �al���r.

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
            //ViewBag dynamic yap�da oldu�u i�in herhangi bir t�rde veri ta��yabiliriz.

            //viewdata key-value yap�s�nda �al���r. veriyi 1 action boyunca tutar.
            ViewData["soyad"]="T�rk";

            //TempData key-value yap�s�nda �al���r. veriyi 2 action boyunca tutar.
            TempData["cinsiyet"]="Erkek";
            TempData.Keep("cinsiyet"); //TempData verisini korur.
            return View();
        }

        public IActionResult About()
        {
            ViewBag.text=ViewBag.ad;//ViewBag ile veri ta��namaz.
            //var msg = TempData["cinsiyet"];//TempData ile veri ta��nabilir.
            
            TempData["c"]= TempData["cinsiyet"];//TempData ile veri ta��nabilir.

            return View();
        }

       
    }
}
