using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcVadisi.Models.entity;
using System.Web.Security;

namespace PcVadisi.Controllers
{
    public class AdminPageController : Controller
    {
        // GET: AdminPage
       
        [HttpGet]
        public ActionResult Loginpage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginpage( Admins p)

        {
            OdpMvcEntities c = new OdpMvcEntities();
            var adminuserinfo = c.Admins.FirstOrDefault(m=>m.AdminUserName == p.AdminUserName && m.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "kategori");
            }
            else
            {
                ViewBag.TekrarDene = "Kullanıcı adı veya şifre hata !!!  Lütfen tekrardan deneyiniz...";
                //return RedirectToAction("Loginpage");
            }
            return View();
           
        }


    }
}