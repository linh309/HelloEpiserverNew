using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType]
    public class CommonPage: PageData
    {
        public virtual string MainIntro { get; set; }

        public virtual XhtmlString MainBody { get; set; }
    }
}