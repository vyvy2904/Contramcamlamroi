﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       private DBSportStoreEntities1 db = new DBSportStoreEntities1();
        //public ActionResult Index(string _name)
        //{
        //    if (_name == null)
        //        return View(db.Products.ToList());
        //    else
        //        return View(db.Products.Where(s => s.NamePro.Contains(_name)).ToList());

        //}
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(AdminUser _user)
        {
            var check = db.AdminUsers
                .Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
            if (check == null) //login sai thong tin
            {
                ViewBag.ErrorInfo = "Sai Infor";
                return View("LoginAdmin");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                Session["NameUser"] = _user.NameUser;
                return RedirectToAction("Index_Admin", "Product");

            }
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("LoginAdmin", "Admin");
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
        public ActionResult RegisterAdmin()
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
        public ActionResult RegisterAdmin(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = db.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault();
                if (check_ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.AdminUsers.Add(_user);
                    db.SaveChanges();
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
