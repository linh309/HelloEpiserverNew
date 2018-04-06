using EPiServer.Core;
using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace MyEpiserverSite.Model.ViewModel
{
    public interface IPageViewModel<out T> where T: PageData
    {
        T CurrentPage { get; }
        IContent Section { get; set; }
    }

    public class DefaultViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public DefaultViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            //Section = EPiServer.HtmlParsing.ContextExtensions.
        }

        public T CurrentPage { get; set; }
        public IContent Section { get; set; }
    }
}

namespace MyEpiserverSite.Controllers
{
    public class CommonPageController : PageController<CommonPageUpdated>
    {
        // GET: CommonPage
        public ActionResult Index(CommonPageUpdated currentPage)
        {
            var contentLink = currentPage;
            return View(currentPage);
        }
    }
}