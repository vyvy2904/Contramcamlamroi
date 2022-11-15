using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BANHANG.Models;


namespace BANHANG.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private DBSportStoreEntities db = new DBSportStoreEntities();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category1);
            return View(products.ToList());
        }
        [HttpPost]
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.Products.ToList());
            else
                return View(db.Products.Where(s => s.NameCate.Contains(_name)).ToList());
        }
    }
}