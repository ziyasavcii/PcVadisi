using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcVadisi.Models.entity;

namespace PcVadisi.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        OdpMvcEntities pca = new OdpMvcEntities();
        [Authorize]
        public ActionResult Index()
        {

            var degerler = pca.urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult yeniurunler()
        {
            List<SelectListItem> degerler = (from i in pca.kotegori.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = i.kategoriad,
                                                 Value = i.kotegoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult yeniurunler(urunler p1)
        {
            var ktg = pca.kotegori.Where(m => m.kotegoriid == p1.kotegori.kotegoriid).FirstOrDefault();
                p1.kotegori = ktg;
            pca.urunler.Add(p1);
            pca.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult DeleteUrun(int id)
        {
            var bulunanId = pca.urunler.Find(id);
            pca.urunler.Remove(bulunanId);
            pca.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult urunGetir (int id)
        {
            var urn = pca.urunler.Find(id);
            
            List<SelectListItem> degerler = (from i in pca.kotegori.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = i.kategoriad,
                                                 Value = i.kotegoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("urunGetir", urn);
        }


        [Authorize]
        public ActionResult Guncelle(urunler p)
        {
            var urn = pca.urunler.Find(p.urunid);
            urn.urunad = p.urunad;
            var ktg = pca.kotegori.Where(m => m.kotegoriid == p.kotegori.kotegoriid).FirstOrDefault();
            urn.urunkateogori = ktg.kotegoriid;
            urn.marka = p.marka;
            urn.fiyat = p.fiyat;
            urn.stok = p.stok;
            pca.SaveChanges();
            return RedirectToAction("Index");
        }


       
       
      
    }
}