using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Controllers
{
    public class StartPageController : PageController<Models.Pages.StartPage>
    {
        // GET: StartPage
        public ActionResult Index(Models.Pages.StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}