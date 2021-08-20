using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vtUyg.ViewModel;

namespace vtUyg.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DilekContext db = new DilekContext();

        public ActionResult Index()
        {
            List<kayitModel> kayitListe = db.Kayitlar.ToList();
            return View(kayitListe);
        }

        public ActionResult yeniKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniKayit(kayitModel model)
        {
            kayitModel kayit = new kayitModel();
            kayit.adsoyad = model.adsoyad;
            kayit.mail = model.mail;
            kayit.yas = model.yas;

            db.Kayitlar.Add(kayit);
            db.SaveChanges();

            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();
        }

        public ActionResult kayitDuzenle(int? id)
        {
            kayitModel kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();
            kayitModel model = new kayitModel();
            model.kayId = kayit.kayId;
            model.adsoyad = kayit.adsoyad;
            model.mail = kayit.mail;
            model.yas = kayit.yas;

            return View(model);
        }

        public ActionResult kayitSil(int? id)
        {
            kayitModel kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();
            db.Kayitlar.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult kayitDuzenle(kayitModel m)
        {
            kayitModel kayit = db.Kayitlar.Where(k => k.kayId == m.kayId).SingleOrDefault();
            kayit.adsoyad = m.adsoyad;
            kayit.mail = m.mail;
            kayit.yas = m.yas;
            db.SaveChanges();

            ViewBag.sonuc = "Kayıt Güncellendi";
            return View();
        }

    }
}