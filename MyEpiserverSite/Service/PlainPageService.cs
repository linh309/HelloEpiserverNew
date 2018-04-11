using EPiServer;
using EPiServer.Core;
using MyEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Service
{
    public interface IPlainPageService
    {
        object GetPropertyByName(int pageId, string propName);
    }

    public class PlainPageService : IPlainPageService
    {
        private IContentRepository _loader;
        public PlainPageService(IContentRepository loader)
        {
            _loader = loader;
        }

        public object GetPropertyByName(int pageId, string propName)
        {
            object value = null;

            var page = _loader.Get<PlainPage>(new PageReference(pageId));
            if (page.Property.Contains(propName))
            {
                value = page.Property[propName];
            }

            return value;
        }
    }
}