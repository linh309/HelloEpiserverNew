using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web.Mvc;
using MyEpiserverSite.Models.Pages;
using MyEpiserverSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace MyEpiserverSite.Model.ViewModel
{
    public interface IPageViewModel<out T> where T : PageData
    {
        T CurrentPage { get; }
        IContent Section { get; set; }
    }

    public class DefaultViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public DefaultViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            //Section = EPiServer.HtmlParsing.ContextExtensions.
        }

        public T CurrentPage { get; set; }
        public IContent Section { get; set; }
    }
}

namespace MyEpiserverSite.Controllers
{
    public class CommonPageController : PageController<CommonPageUpdated>
    {
        // GET: CommonPage
        public ActionResult Index(CommonPageUpdated currentPage)
        {
            var viewModel = new CommonPageViewModel(currentPage);
            EPiServer.Core.PropertyData firstProperty = currentPage.Property.FirstOrDefault();


            PropertyDefinition a = new PropertyDefinition();

            var propertyCollection = currentPage.Property;
            var propMainIntro = currentPage.Property["MainIntro"];
            var value = propMainIntro.Value;
            //propMainIntro.Value = "Changed";

            var propbSubsidiaries = currentPage.Property["Subsidiaries"];
            var dictSubsidiaries = DictSubsidiaries("Subsidiaries");

            foreach (var itemDict in dictSubsidiaries)
            {
                if (propbSubsidiaries != null && !string.IsNullOrEmpty(propbSubsidiaries.ToString()) && propbSubsidiaries.Value.ToString().Contains(itemDict.Key))
                {
                    viewModel.AvailableCountries += itemDict.Value + ", ";
                }
            }

            var contentLink = currentPage;
            return View(viewModel);
        }

        private Dictionary<string, string> DictSubsidiaries(string key)
        {
            var dict = new Dictionary<string, string>();
            var subsidiariesValue = ReadAppSetting(key);
            if (!string.IsNullOrEmpty(subsidiariesValue))
            {
                dict = subsidiariesValue.Split('|').ToList().ToDictionary(x => x.Split(';')[1], x => x.Split(';')[0]);
            }

            return dict;
        }

        private string ReadAppSetting(string key)
        {
            string value = string.Empty;
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.AllKeys.Contains(key))
            {
                value = appSettings[key];
            }

            return value;
        }
    }
}