using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;
using System.Web.Mvc;

namespace MyEpiserverSite.Controllers
{
    [ContentType(DisplayName = "StandardPageController", GUID = "f7b119d6-2af0-4d25-be1d-78d07c232b00", Description = "")]
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            return View(currentPage);
        }
    }
}