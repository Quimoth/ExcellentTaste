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
    public class TableModelController : Controller
    {
        private ETContext db = new ETContext();

        // GET: TableModel
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        public ActionResult TableOverview()
        {
            return View(db.Tables.ToList());
        }

        // GET: TableModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = db.Tables.Find(id);
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            return View(tableModel);
        }

        // GET: TableModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TableId,TableStatus")] TableModel tableModel)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(tableModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableModel);
        }

        // GET: TableModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = db.Tables.Find(id);
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            return View(tableModel);
        }

        // POST: TableModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TableId,TableStatus")] TableModel tableModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableModel);
        }

        // GET: TableModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = db.Tables.Find(id);
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            return View(tableModel);
        }

        // POST: TableModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableModel tableModel = db.Tables.Find(id);
            db.Tables.Remove(tableModel);
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
