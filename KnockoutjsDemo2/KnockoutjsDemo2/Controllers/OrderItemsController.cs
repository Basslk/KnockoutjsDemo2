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
    public class OrderItemsController : Controller
    {
        private KnockoutjsDemo2Context context = new KnockoutjsDemo2Context();

        //
        // GET: /OrderItems/

        public ViewResult Index()
        {
            return View(context.OrderItems.Include(orderitem => orderitem.Product).ToList());
        }

        //
        // GET: /OrderItems/Details/5

        public ViewResult Details(int id)
        {
            OrderItem orderitem = context.OrderItems.Single(x => x.Id == id);
            return View(orderitem);
        }

        //
        // GET: /OrderItems/Create

        public ActionResult Create()
        {
            ViewBag.PossibleProducts = context.Products;
            return View();
        } 

        //
        // POST: /OrderItems/Create

        [HttpPost]
        public ActionResult Create(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.OrderItems.Add(orderitem);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleProducts = context.Products;
            return View(orderitem);
        }
        
        //
        // GET: /OrderItems/Edit/5
 
        public ActionResult Edit(int id)
        {
            OrderItem orderitem = context.OrderItems.Single(x => x.Id == id);
            ViewBag.PossibleProducts = context.Products;
            return View(orderitem);
        }

        //
        // POST: /OrderItems/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.Entry(orderitem).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleProducts = context.Products;
            return View(orderitem);
        }

        //
        // GET: /OrderItems/Delete/5
 
        public ActionResult Delete(int id)
        {
            OrderItem orderitem = context.OrderItems.Single(x => x.Id == id);
            return View(orderitem);
        }

        //
        // POST: /OrderItems/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderitem = context.OrderItems.Single(x => x.Id == id);
            context.OrderItems.Remove(orderitem);
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