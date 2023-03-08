using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class LoginController : Controller
    {
        DbTransportEntities db = new DbTransportEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            var values = db.TblAdmin.Where(x => x.UserName == t.UserName & x.Password == t.Password).FirstOrDefault();
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = t.UserName;
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
    }
}