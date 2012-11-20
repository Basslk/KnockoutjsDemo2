using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutjsDemo2.Models;

namespace KnockoutjsDemo2.Controllers
{   
    public class OrdersController : Controller
    {
        private KnockoutjsDemo2Context context = new KnockoutjsDemo2Context();

        //
        // GET: /Orders/

        public ViewResult Index()
        {
            return View(context.Orders.Include(order => order.OrderItems).ToList());
        }

        //
        // GET: /Orders/Details/5

        public ViewResult Details(int id)
        {
            Order order = context.Orders.Single(x => x.Id == id);
            return View(order);
        }

        public class CreateOrderViewModel
        {
            public List<Product> Group1 { get; set; }
            public List<Product> Group2 { get; set; }
            public List<Product> Group3 { get; set; }
        }
        /*public JsonResult CreateBundle()
        {
            CreateOrderViewModel model = new CreateOrderViewModel();
            model.Group1 = context.Products.Where(p => p.Type == "type150").ToList();
            model.Group2 = context.Products.Where(p => p.Type == "type200").ToList();
            model.Group3 = context.Products.Where(p => p.Type == "type300").ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        */
        public JsonResult CreateBundle1()
        {
            return Json(context.Products.Where(p => p.Type == "type150").ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateBundle2()
        {
            return Json(context.Products.Where(p => p.Type == "type200").ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateBundle3()
        {
            return Json(context.Products.Where(p => p.Type == "type300").ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Orders/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Orders/Create

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(order);
        }
        
        //
        // GET: /Orders/Edit/5
 
        public ActionResult Edit(int id)
        {
            Order order = context.Orders.Single(x => x.Id == id);
            return View(order);
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Orders/Delete/5
 
        public ActionResult Delete(int id)
        {
            Order order = context.Orders.Single(x => x.Id == id);
            return View(order);
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = context.Orders.Single(x => x.Id == id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}