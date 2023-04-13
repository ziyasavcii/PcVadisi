using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcVadisi.Models.entity;


namespace PcVadisi.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        OdpMvcEntities pc = new OdpMvcEntities();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = pc.kotegori.ToList();
            return View(degerler);
        }


        [HttpGet]
        [Authorize]
        public ActionResult yenikategori ()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult yenikategori(kotegori p1)
        {
            pc.kotegori.Add(p1);
            pc.SaveChanges();
            return View();
        }

        [Authorize]
        public ActionResult DeleteKategori(int id)
        {
            var bulunanId = pc.kotegori.Find(id);
            pc.kotegori.Remove(bulunanId);
            pc.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = pc.kotegori.Find(id);
            return View("KategoriGetir", ktgr);
        
        }

        [Authorize]
        public ActionResult guncelle (kotegori p1)
        {
            var ktg = pc.kotegori.Find(p1.kotegoriid);
            ktg.kategoriad = p1.kategoriad;

            pc.SaveChanges();
            return RedirectToAction("index");
        }
   
    }
}