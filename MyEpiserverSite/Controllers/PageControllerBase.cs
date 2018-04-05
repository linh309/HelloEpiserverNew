using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;

namespace MyEpiserverSite.Controllers
{
    public class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        public ActionResult Logout(T currentPage)
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}