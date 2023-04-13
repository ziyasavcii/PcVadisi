using PcVadisi.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcVadisi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin

        OdpMvcEntities pca = new OdpMvcEntities();

        public ActionResult Index()
        {
            var values = pca.urunler.OrderByDescending(x => x.urunid).ToList();
            return View(values);
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult iletisim()
        {
            return View();
        }

    }
}