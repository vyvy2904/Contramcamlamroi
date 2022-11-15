using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{

    public class LoginUserController : Controller
    {
        DBSportStoreEntities1 database = new DBSportStoreEntities1();
        // GET: LoginUser : Form Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAcount(AdminUser _user)
        {
            var check = database.AdminUsers
                .Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
            if (check == null) //login sai thong tin
            {
                ViewBag.ErrorInfo = "Sai Infor";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
               
                Session["NameUser"] = _user.NameUser;
                return RedirectToAction("Index", "Product");

            }
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
        // GET: LoginUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginUser/Create
        public ActionResult RegisterUser()
        {
            return View();
        }

            [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginUser/Delete/
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult RegisterUser(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.AdminUsers.Where(s => s.ID == _user.ID ).FirstOrDefault();
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.AdminUsers.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exixst";
                    return View();
                }
            }
            return View();
        }
    }
}

