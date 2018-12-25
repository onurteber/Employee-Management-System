using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Project.Models.Data.Context;
using MVC_Project.Models.Data.Model;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class DepartmanController : BaseController
    {
        MVCProjectContext db = new MVCProjectContext();

        // GET: Departman
        
        public ActionResult Index()
        {
            var model = db.Departmanlar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm",new Departman());
        }

        [ValidateAntiForgeryToken]

        public ActionResult Kaydet(Departman departman)
        {
            if(!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();
            if(departman.DepartmanID==0)
            {
                db.Departmanlar.Add(departman);
                model.Mesaj = departman.Ad + " Eklendi.";
            }
            else
            {
                var guncellenecekDepartman = db.Departmanlar.Find(departman.DepartmanID);
                
                if(guncellenecekDepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + " Güncellendi.";
            }
            db.SaveChanges();

            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj",model);
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departmanlar.Find(id);
            if(model==null)           
                return HttpNotFound();            
            return View("DepartmanForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departmanlar.Find(id);
            if(silinecekDepartman!=null)
            {
                db.Departmanlar.Remove(silinecekDepartman);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", silinecekDepartman);
        }
       
    }
}