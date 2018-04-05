using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "5064441a-7a4a-4095-b44d-faa0bcf11a3a", Description = "")]
    public class ArticlePage : SitePageData
    {

        [CultureSpecific]
        [Display(Name = "Introduction", Description = "Introduce describle", GroupName = SystemTabNames.Content, Order = 1)]
        public String Introduction { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString MainBody { get; set; }

    }
}