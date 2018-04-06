using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Pages
{
    [ContentType]
    public class ProductPage: PageData
    {
        public virtual string Title { get; set; }
        public virtual string Desc { get; set; }
    }
}