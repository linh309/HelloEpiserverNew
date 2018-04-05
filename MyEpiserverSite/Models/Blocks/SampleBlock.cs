using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace MyEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "SampleBlock", GUID = "96a18a9b-b342-4715-bdde-1685c3d8017c", Description = "")]
    public class SampleBlock : BlockData
    {

        [CultureSpecific]
        [Display(Name = "Title", Description ="Title's field", GroupName = SystemTabNames.Content, Order = 0)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Name { get; set; }

    }
}