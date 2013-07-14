using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WoolBoxStudio.Controllers
{
    [AllowAnonymous]
    public class CraftShow : Controller
    {
        //
        // GET: /CraftShow/

        public ActionResult Index()
        {
            return View();
        }

    }
}
