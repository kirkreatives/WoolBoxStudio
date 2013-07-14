using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Models;


namespace WoolBoxStudio.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private WoolBoxStudioContext db = new WoolBoxStudioContext();

        public ActionResult Index()
        {
            var homeCarousel = db.HomeCarousels;
            return View(homeCarousel.ToList());
        }

        public ActionResult Portfolio()
        {
            var portfolios = db.Portfolios.Include(p => p.Category);
            return View(portfolios.ToList());
        }

        public ActionResult PortfolioDetails(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return PartialView(portfolio);
        }

        public ActionResult CraftShows()
        {
            var craftShows = db.CraftShows;
            return View(craftShows.ToList());
        }

        public ActionResult Locations()
        {
            var locations = db.Locations;
            return View(locations.ToList());
        }

        public ActionResult About()
        {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(EmailForm emailform)
        {
            if (ModelState.IsValid)
            {
                //create a email
                MailMessage emailMessage = new MailMessage();
                emailMessage.Subject = emailform.Subject;
                emailMessage.Body = emailform.Message;
                emailMessage.From = new MailAddress(emailform.Email, emailform.Name);
                emailMessage.To.Add(new MailAddress("qqazqqaz@gmail.com", "Site Admin"));

                //create smtp object and send the email above
                SmtpClient emailSmtpClient = new SmtpClient();
                emailSmtpClient.Send(emailMessage);

                return RedirectToAction("Index", "Home");
            }
            //return PartialView("~/Views/Home/About", emailform);
            return View(emailform);
        }
    }
}
