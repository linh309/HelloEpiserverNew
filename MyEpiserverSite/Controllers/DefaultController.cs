using EPiServer;
using EPiServer.Web.Mvc;
using MyEpiserverSite.Model.ViewModel;
using MyEpiserverSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Controllers
{
    public class DefaultController : PageController<EPiServer.Core.PageData>
    {
        // GET: Default
        public ActionResult Index(EPiServer.Core.PageData currentPage)
        {
            //get type of currentPage
            var type = typeof(PageViewModel<>).MakeGenericType(currentPage.GetOriginalType());
            var model = Activator.CreateInstance(type, currentPage) as IPageViewModel<EPiServer.Core.PageData>;
            var viewName = $"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml";
            return View(viewName, model);
        }
    }
}