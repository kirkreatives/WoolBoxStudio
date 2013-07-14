using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolBoxStudio.Filters;

namespace WoolBoxStudio.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

    }
}
