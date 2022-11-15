using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class OrderDetailController : Controller
    {
        DBSportStoreEntities1 database = new DBSportStoreEntities1();
        // GET: OrderDetail
        public ActionResult GroupByTop5()
        {
            List<OrderDetail> ordersD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in ordersD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price
                        } into gr
                        orderby gr.Sum(s => s.Quantity) descending
                        select new ViewModel
                        {
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImgPro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            Sum_Quantity = gr.Sum(s => s.Quantity)
                        };
            return View(query.Take(5).ToList());
         }
        public ActionResult Create()
        {
            List<Category> list = database.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product pro = new Product();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            List<Category> list = database.Categories.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent =  Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}