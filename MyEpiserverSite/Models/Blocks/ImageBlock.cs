using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "Image Block", Description = "Image block", GUID = "79C37F89-0334-4431-BEBC-3F454ABCA1B4")]
    public class ImageBlock : BlockData
    {
        [Display(Name ="Title",Description ="Title")]        
        public virtual string Title { get; set; }

        //[Display(Name = "Image", Description = "Image")]
        //public virtual ContentReference Image { get; set; }
    }
}