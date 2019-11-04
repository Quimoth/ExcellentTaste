using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExcellentTaste.DAL;
using ExcellentTaste.Models;

namespace ExcellentTaste.Controllers
{
    public class ProductOrderModelController : Controller
    {
        private ETContext db = new ETContext();

        // GET: ProductOrderModel
        public ActionResult Index()
        {
            return View(db.ProductOrders.ToList());
        }

        // GET: ProductOrderModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderModel productOrderModel = db.ProductOrders.Find(id);
            if (productOrderModel == null)
            {
                return HttpNotFound();
            }
            return View(productOrderModel);
        }

        // GET: ProductOrderModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOrderModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductOrderId,ProductOrderStatus")] ProductOrderModel productOrderModel)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrders.Add(productOrderModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productOrderModel);
        }

        // GET: ProductOrderModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderModel productOrderModel = db.ProductOrders.Find(id);
            if (productOrderModel == null)
            {
                return HttpNotFound();
            }
            return View(productOrderModel);
        }

        // POST: ProductOrderModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductOrderId,ProductOrderStatus")] ProductOrderModel productOrderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOrderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productOrderModel);
        }

        // GET: ProductOrderModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderModel productOrderModel = db.ProductOrders.Find(id);
            if (productOrderModel == null)
            {
                return HttpNotFound();
            }
            return View(productOrderModel);
        }

        // POST: ProductOrderModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOrderModel productOrderModel = db.ProductOrders.Find(id);
            db.ProductOrders.Remove(productOrderModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
