using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "981d4679-016c-449e-841e-342f4bf315e4", Description = "Standard page", GroupName = "Editoral")]
    [ImageUrl("~/Content/imgs/page-type-thumbnail-contact.png")]
    public class StandardPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "The page heading.",
            GroupName = SystemTabNames.Content,
            Order = 0)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}