using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Filters;
using WoolBoxStudio.Models;

namespace WoolBoxStudio.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = "Administrator")]
    public class AboutController : Controller
    {
        private WoolBoxStudioContext db = new WoolBoxStudioContext();

        //
        // GET: /About/

        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        //
        // GET: /About/Details/5

        public ActionResult Details(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // GET: /About/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /About/Create

        [HttpPost]
        public ActionResult Create(About about, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/About/") + file.FileName);
                        about.ImageLink = "../Images/About/" + file.FileName;
                        db.Abouts.Add(about);
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
            return View(about);
        }

        //
        // GET: /About/Edit/5

        public ActionResult Edit(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // POST: /About/Edit/5

        [HttpPost]
        public ActionResult Edit(About about, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                        about.ImageLink = "../Images/About/" + file.FileName;
                        db.Entry(about).State = EntityState.Modified;
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
            return View(about);
        }

        //
        // GET: /About/Delete/5

        public ActionResult Delete(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // POST: /About/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.Abouts.Find(id);
            db.Abouts.Remove(about);
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