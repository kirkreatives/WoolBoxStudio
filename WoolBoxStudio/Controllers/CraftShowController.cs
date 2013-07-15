using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Models;
using WoolBoxStudio.Filters;
using System.IO;

namespace WoolBoxStudio.Controllers
{
    public class CraftShowController : Controller
    {
        private WoolBoxStudioContext db = new WoolBoxStudioContext();

        //
        // GET: /CraftShow/

        public ActionResult Index()
        {
            return View(db.CraftShows.ToList());
        }

        //
        // GET: /CraftShow/Details/5

        public ActionResult Details(int id = 0)
        {
            CraftShow craftshow = db.CraftShows.Find(id);
            if (craftshow == null)
            {
                return HttpNotFound();
            }
            return View(craftshow);
        }

        //
        // GET: /CraftShow/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CraftShow/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CraftShow craftshow)
        {
            if (ModelState.IsValid)
            {
                db.CraftShows.Add(craftshow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(craftshow);
        }

        //
        // GET: /CraftShow/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CraftShow craftshow = db.CraftShows.Find(id);
            if (craftshow == null)
            {
                return HttpNotFound();
            }
            return View(craftshow);
        }

        //
        // POST: /CraftShow/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CraftShow craftshow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(craftshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(craftshow);
        }

        //
        // GET: /CraftShow/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CraftShow craftshow = db.CraftShows.Find(id);
            if (craftshow == null)
            {
                return HttpNotFound();
            }
            return View(craftshow);
        }

        //
        // POST: /CraftShow/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CraftShow craftshow = db.CraftShows.Find(id);
            db.CraftShows.Remove(craftshow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}