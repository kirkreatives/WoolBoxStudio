using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Filters;
using WoolBoxStudio.Models;
using System.IO;

namespace WoolBoxStudio.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = "Administrator")]
    public class PortfolioController : Controller
    {
        private WoolBoxStudioContext db = new WoolBoxStudioContext();

        //
        // GET: /Portfolio/

        public ActionResult Index()
        {
            var portfolios = db.Portfolios.Include(p => p.Category);
            return View(portfolios.ToList());
        }

        //
        // GET: /Portfolio/Details/5

        public ActionResult Details(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }

        //
        // POST: /Portfolio/Create

        [HttpPost]
        public ActionResult Create(Portfolio portfolio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/Portfolio/") + file.FileName);
                        portfolio.ImageLink = "../Images/Portfolio/" + file.FileName;
                        db.Portfolios.Add(portfolio);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("ImageLink", "Image must be a .jpg, .png, or .gif format");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageLink", "Image must be uploaded");
                }
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", portfolio.CategoryID);
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", portfolio.CategoryID);
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Edit/5

        [HttpPost]
        public ActionResult Edit(Portfolio portfolio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/Portfolio/") + file.FileName);
                        portfolio.ImageLink = "../Images/Portfolio/" + file.FileName;
                        db.Entry(portfolio).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("ImageLink", "Image must be a .jpg, .png, or .gif format");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageLink", "Image must be uploaded");
                }
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", portfolio.CategoryID);
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
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