using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Filters;
using WoolBoxStudio.Models;

namespace WoolBoxStudio.Controllers
{
    [AllowAnonymous]
    public class CraftShowController : Controller
    {
        //
        // GET: /CraftShow/

        public ActionResult Index()
        {
            return View();
        }

    }
}
