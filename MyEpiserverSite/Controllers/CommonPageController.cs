using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Controllers
{
    public class CommonPageController : PageController<CommonPage>
    {
        // GET: CommonPage
        public ActionResult Index(CommonPage currentPage)
        {
            return View(currentPage);
        }
    }
}