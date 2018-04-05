using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "SitePageData", GUID = "8e635732-da1f-45e8-92c8-04c57a9e1d3d", Description = "")]
    public class SitePageData : PageData
    {
        [Display(GroupName ="SEO", Order = 200, Name = "Search keywords")]
        public virtual String MetaKeyword { get; set; }

        [CultureSpecific]
        [Display(Name = "Heading", Description = "Heading of page", GroupName = SystemTabNames.Content, Order = 0)]
        public virtual String Heading { get; set; }
    }
}