using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DbTransportEntities db = new DbTransportEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var values = Session["UserName"];
            var uservalue = db.TblAdmin.Where(x => x.UserName == values).FirstOrDefault();
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult Index(TblAdmin tblAdmin)
        {
            return View();
        }
    }
}