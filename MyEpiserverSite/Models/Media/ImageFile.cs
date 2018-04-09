using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Media
{
    [ContentType]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
        public virtual string AlternativeText { get; set; }
    }
}