using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Controllers
{
    public class ProductController : PageController<ProductPage>
    {
        // GET: Product
        public ActionResult Index(ProductPage currentPage)
        {
            return View(currentPage);
        }
    }
}