using MVC_Project.Models.Data.Context;
using MVC_Project.Models.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Project.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MVCProjectContext db = new MVCProjectContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullanici_ = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            if (kullanici_!=null)
            {
                FormsAuthentication.SetAuthCookie(kullanici_.KullaniciAdi, false);
                Session["Kullanici"] = kullanici_;
                return RedirectToAction("Index","Departman");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı ya da Şifre Hatalı.";
                return View();
            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}