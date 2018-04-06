using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Pages
{
    public class BasePage: PageData
    {
        public virtual string Title { get; set; }
        public virtual string MetaDescription { get; set; }
    }
}