using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private DBSportStoreEntities1 db = new DBSportStoreEntities1();
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.Customer.ToList());
            else
                return View(db.Customer.Where(s => s.NameCus.Contains(_name)).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            try
            {
                db.Customer.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index_Admin");
            }
            catch
            {
                return Content("Error Craete New");
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.Customer.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer name)
        {
            db.Entry(name).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(db.Customer.Where(s => s.IDCus == id).FirstOrDefault());
        }
    }
}