using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string AdSoyad = "kaan";
            ViewBag.AdSoyad = AdSoyad;
            ViewData["AdSoyad2"] = AdSoyad;
            TempData["Yas"] = AdSoyad; //Diğerlerinden farkı sadece bir View e özgü değil globaldir.
            //Model olarak tanıtma
            Customer customer = new (){ Adi = "kaan",Soyadi="akbaş",TelefonNo="0531"};


            /*return View(customer);*/ // model gönderme
            return RedirectToAction("About", customer);
        }
        public IActionResult About(Customer _customer)
        {
            //return View("Index", new Customer() { Adi = "nedim",Soyadi="akbaş",TelefonNo = "265" }); //View'in 4 kullanımı vardır. Bak bir ara
            return View("Index", _customer);
        }
    }
}
