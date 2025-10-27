using _13_State_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            //Session'a veri ekleme
            //Cookie (Çerezler)
            //Session stateler uygulama çalýþtýðu süre boyunca  verileri saklamamýzý saðlayan yapýlardýr.
            //Oturum sona erdiðinde (Uygulama kapatýldýðýnda) session veriler otomatik olarak silinir.
            //Session verileri sunucu tarafýnda saklanýr.
            //Session Özelbilgiler saklamak önerilmez.

            //UserName adýnda bir session oluþturup içine "Erkan Türk" deðerini atýyoruz.
            //Key value (anahtar-deðer) yapýsý ile çalýþýr.
            HttpContext.Session.SetString("UserName", "Erkan Türk");
            ViewBag.UserName= HttpContext.Session.GetString("UserName");
            //GetString ile session içerisindeki veriyi alýyoruz.

            //Cookie (Çerezler)
            //Cookie'ler kullanýcý tarafýnda (Tarayýcýda) saklanýr.
            //Key-Value (Anahtar-Deðer) yapýsý ile çalýþýr.
            //Bir expire (son kullanma) süresi belirlenebilir.
            //Bu son kullanma süresi dolduðunda cookie otomatik olarak silinir.
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMinutes(10), //Çerezin 10 dakika sonra sona oturum geçerliliðini yitirir.
                HttpOnly = true, //Sadece HTTP isteklerinde eriþilebilir, JavaScript tarafýndan eriþilemez.
                IsEssential = true //Çerezin temel iþlevsellik için gerekli olduðunu belirtir.
            };
            Response.Cookies.Append("UserName", "Erkan Türk", cookieOptions);
            //Response.Cookies.Append ile cookie oluþturuyoruz. 
            var cookieUserName = Request.Cookies["UserName"];
            ViewBag.CookieUserName = cookieUserName;
            return View();
        }

       
    }
}
