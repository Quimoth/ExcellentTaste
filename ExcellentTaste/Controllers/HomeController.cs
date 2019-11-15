using ExcellentTaste.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcellentTaste.Models;
using ExcellentTaste.ViewModels;

namespace ExcellentTaste.Controllers
{
    public class HomeController : Controller
    {
        private ETContext db = new ETContext();

        public ActionResult Index()

        {
            List<TableModel> tables = db.Tables.ToList(); /*Where(x => x.TableStatus == TableModel.TableStat.Vrij).ToList();*/
            return View(tables);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Kitchen()
        {
            return View(db.ProductOrders.Include("Product").Where(x => x.ProductOrderStatus == Status.Preparing && (int)x.Product.ProductType > 2));
        }

        public ActionResult DishDone(int id)
        {
            ProductOrderModel productOrder = db.ProductOrders.Include("Product").First(x => x.ProductOrderId == id);
            FoodType foodType = productOrder.Product.ProductType;
            productOrder.ProductOrderStatus = Status.Done;
            db.Entry(productOrder).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            if((int)foodType > 2)
            {
                return RedirectToAction("Kitchen");
            }
            else
            {
                return RedirectToAction("Bar");
            }
        }

        public ActionResult Bar()
        {
            return View(db.ProductOrders.Include("Product").Where(x=> x.ProductOrderStatus == Status.Preparing && (int)x.Product.ProductType < 3));
        }
    }
}