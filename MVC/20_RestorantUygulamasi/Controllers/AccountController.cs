using _20_RestorantUygulamasi.DataContext;
using _20_RestorantUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20_RestorantUygulamasi.Controllers
{
    public class AccountController : Controller
    {
        private readonly RestorantContext _context;
        public AccountController(RestorantContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi==kullaniciAdi&&k.Sifre==sifre);
            if (kullanici!=null)
            {
                HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi);
                HttpContext.Session.SetString("Rol", kullanici.Rol);
                return RedirectToAction("Index", "Garson");
            }
            ViewBag.ErrorMessage="Kullanıcı Adı veya Şifre Hatalıdır";
            return View();

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
      //register oluşturulacak ve admin tarafı bu kayıt işlemini yapacak

    }
}
