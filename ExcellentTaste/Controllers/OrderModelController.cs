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
using ExcellentTaste.ViewModels;

namespace ExcellentTaste.Controllers
{
    public class OrderModelController : Controller
    {
        private ETContext db = new ETContext();

        // GET: OrderModel
        public ActionResult Index()
        {
            //List<OrderViewModel> orderList = new List<OrderViewModel>();
            //foreach(var order in db.Orders)
            //{
            //    OrderViewModel orderViewModel = new OrderViewModel(order);
            //    orderList.Add(orderViewModel);
            //}
            List<OrderModel> orderList = db.Orders.Include(m => m.Products.Select(x => x.Product)).ToList();
            return View(orderList);
        }

        // GET: OrderModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // GET: OrderModel/Create
        public ActionResult Create()
        {
            OrderViewModel newModel = new OrderViewModel();
            newModel.AllTables = db.Tables.Where(x => x.TableStatus == TableModel.TableStat.Vrij).ToList();
            newModel.AllProducts = db.Products.Where(x => x.Availability > 0).ToList();
            newModel.TimeStamp = DateTime.Now;
            string errMsg = "";
            if (TempData["ErrorMessage"] != null)
            {
                errMsg = TempData["ErrorMessage"] as string;
            }
            ViewBag.ErrorText = errMsg;
            return View(newModel);
        }

        // POST: OrderModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderStatus,TimeStamp,Table,Tables,TableIds,ProductIds")] OrderViewModel orderViewModel)
        {
            if (orderViewModel.TableIds == null)
            {
                TempData["ErrorMessage"] = "Je moet mininaal één tafel selecteren";
                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                OrderModel order = new OrderModel();
                order.TimeStamp = orderViewModel.TimeStamp;
                order.Products = new List<ProductOrderModel>();
                order.Tables = new List<TableModel>();
                foreach (int prod in orderViewModel.ProductIds)
                {
                    ProductOrderModel productOrder = new ProductOrderModel()
                    {
                        Product = db.Products.First(x => x.ProductId == prod),
                        ProductOrderStatus = Status.Preparing,
                    };
                    order.Products.Add(productOrder);
                    ProductModel product = db.Products.First(x => x.ProductId == prod);
                    product.Availability -= 1;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                order.Tables.AddRange(db.Tables.Where(x => orderViewModel.TableIds.Contains(x.TableId)));
                foreach (var table in db.Tables.Where(x => orderViewModel.TableIds.Contains(x.TableId)))
                {
                    table.TableStatus = TableModel.TableStat.Bezet;
                    db.Entry(table).State = EntityState.Modified;
                }
                                
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderViewModel);
        }

        // GET: OrderModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel orderViewModel = new OrderViewModel(db.Orders.Include("Tables").FirstOrDefault(x => x.OrderId == id));
            if (orderViewModel == null)
            {
                return HttpNotFound();
            }
            orderViewModel.AllTables = orderViewModel.Tables;
            orderViewModel.AllTables.AddRange(db.Tables.Where(x => x.TableStatus == TableModel.TableStat.Vrij));
            orderViewModel.AllProducts = db.Products.Where(x => x.Availability > 0).ToList();
            string errMsg = "";
            if (TempData["ErrorMessage"] != null)
            {
                errMsg = TempData["ErrorMessage"] as string;
            }
            ViewBag.ErrorText = errMsg;
            return View(orderViewModel);
        }

        // POST: OrderModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderStatus,TimeStamp,Tables,TableIds,ProductIds")] OrderViewModel orderViewModel)
        {
            if (orderViewModel.TableIds == null)
            {
                TempData["ErrorMessage"] = "Je moet mininaal één tafel selecteren";
                return RedirectToAction("Edit");
            }
            if (ModelState.IsValid)
            {
                OrderModel order = db.Orders.Include("Tables").First(x => x.OrderId == orderViewModel.OrderId);
                order.Tables.AddRange(db.Tables.Where(table => orderViewModel.TableIds.Contains(table.TableId)));
                order.TimeStamp = orderViewModel.TimeStamp;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderViewModel);
        }

        // GET: OrderModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: OrderModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel orderModel = db.Orders.Find(id);
            db.ProductOrders.RemoveRange(orderModel.Products);
            db.Orders.Remove(orderModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel orderViewModel = new OrderViewModel(db.Orders.Include("Products").FirstOrDefault(x => x.OrderId == id));
            if (orderViewModel == null)
            {
                return HttpNotFound();
            }
            orderViewModel.AllProducts = db.Products.Where(x => x.Availability > 0).ToList();
            return View(orderViewModel);
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
