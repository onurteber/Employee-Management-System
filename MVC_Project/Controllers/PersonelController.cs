using MVC_Project.Models.Data.Context;
using MVC_Project.Models.Data.Model;
using MVC_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{
    public class PersonelController : BaseController
    {
        MVCProjectContext db = new MVCProjectContext();

        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personeller.ToList();  
            return View(model);
        }

        [Authorize(Roles ="A")] // Role Yetkilendirme Yapıldı. Kullanici Rol Provider (GetRolesForUser) methoduna gidip kontrol gerçekleştirildi.

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departmanlar.ToList(),
                Personeller = new Personel()
            };
            return View("PersonelForm", model);
        }

        [ValidateAntiForgeryToken] 
        public ActionResult Kaydet(PersonelFormViewModel personel)
        {
            if(!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departmanlar.ToList(),
                    Personeller = personel.Personeller
                };
                return View("PersonelForm",model);
            }
            if(personel.Personeller.PersonelID==0)
            {
                db.Personeller.Add(personel.Personeller);
            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departmanlar.ToList(),
                Personeller = db.Personeller.Find(id)
            };
            return View("PersonelForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekpersonel = db.Personeller.Find(id);
            if(silinecekpersonel==null)
            {
                return HttpNotFound();
            }
            db.Personeller.Remove(silinecekpersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personeller.Where(x => x.DepartmanID == id).ToList();
            return PartialView(model);
        }

        public int ToplamMaas()
        {
            return db.Personeller.Sum(x => x.Maas);
        }
    }

   
}