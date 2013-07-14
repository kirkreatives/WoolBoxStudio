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
    public class HomeCarouselController : Controller
    {
        private WoolBoxStudioContext db = new WoolBoxStudioContext();

        //
        // GET: /HomeCarousel/

        public ActionResult Index()
        {
            return View(db.HomeCarousels.ToList());
        }

        //
        // GET: /HomeCarousel/Details/5

        public ActionResult Details(int id = 0)
        {
            HomeCarousel homecarousel = db.HomeCarousels.Find(id);
            if (homecarousel == null)
            {
                return HttpNotFound();
            }
            return View(homecarousel);
        }

        //
        // GET: /HomeCarousel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HomeCarousel/Create

        [HttpPost]
        public ActionResult Create(HomeCarousel homecarousel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/HomePage/") + file.FileName);
                        homecarousel.ImageLink = "../Images/HomePage/" + file.FileName;
                        db.HomeCarousels.Add(homecarousel);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("ImageLink", "Image must be in either .jpg, .png, or .gif format");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageLink", "Please select an image to upload");
                }
            }
            return View(homecarousel);
        }

        //
        // GET: /HomeCarousel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            HomeCarousel homecarousel = db.HomeCarousels.Find(id);
            if (homecarousel == null)
            {
                return HttpNotFound();
            }
            return View(homecarousel);
        }

        //
        // POST: /HomeCarousel/Edit/5

        [HttpPost]
        public ActionResult Edit(HomeCarousel homecarousel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string[] safeExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (safeExtensions.Contains(extension))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/HomePage/") + file.FileName);
                        homecarousel.ImageLink = "../Images/HomePage/" + file.FileName;
                        db.Entry(homecarousel).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("ImageLink", "Image must be in either.jpg, .png, or .gif format");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageLink", "Please select an image to upload");
                }
            }
            return View(homecarousel);
        }

        //
        // GET: /HomeCarousel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            HomeCarousel homecarousel = db.HomeCarousels.Find(id);
            if (homecarousel == null)
            {
                return HttpNotFound();
            }
            return View(homecarousel);
        }

        //
        // POST: /HomeCarousel/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeCarousel homecarousel = db.HomeCarousels.Find(id);
            db.HomeCarousels.Remove(homecarousel);
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