using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class OrderProController : Controller
    {
        // GET: OrderPro
        private DBSportStoreEntities1 db = new DBSportStoreEntities1();
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.OrderProes.ToList());
            else
                return View(db.OrderProes.Where(s => s.NameCus.Contains(_name)).ToList());

        }
    }
}