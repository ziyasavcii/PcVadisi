using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcVadisi.Models.entity;

namespace PcVadisi.Controllers
{
    public class musteriController : Controller
    {
        // GET: musteri

        OdpMvcEntities pcas = new OdpMvcEntities();
        [Authorize]
        public ActionResult Index()
        {

            var degerler = pcas.musteri.ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult yenimusteri()        {

            return View();

       }


        [HttpPost]
        [Authorize]
        public ActionResult yenimusteri(musteri p1)
        {
            pcas.musteri.Add(p1);
            pcas.SaveChanges();
            return View();

        }
        [Authorize]
        public ActionResult deleteMusteri( int id) {
            var bulunanid = pcas.musteri.Find(id);
            pcas.musteri.Remove(bulunanid);
            pcas.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult musteriGetir(int id)
        { 
            var mus = pcas.musteri.Find(id);
            return View("musteriGetir", mus);

        }
        [Authorize]
        public ActionResult guncelle(musteri p1)
        {
            var must = pcas.musteri.Find(p1.musteriid);
            must.musteriad = p1.musteriad;
            must.musterisoyad = p1.musterisoyad;
            pcas.SaveChanges();
            return RedirectToAction("Index");

        
        
        }
    }
}