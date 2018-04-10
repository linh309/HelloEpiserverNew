using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Plain page", Description = "Page without controller", GUID = "D3839084-D82E-47A2-B32E-9911CD248107")]
    public class PlainPage : PageData
    {
        public virtual string PageTitle { get; set; }
        public virtual string PageDesc { get; set; }
    }
}