using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace MyEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlock", GUID = "9dffdde2-ca42-4e66-b30e-b7d6953d49c8", Description = "")]
    public class TeaserBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Add a heading",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "Image", Description = "Add an image (optional)", GroupName = SystemTabNames.Content, Order = 2)]
        public virtual ContentReference Image { get; set; }

    }
}