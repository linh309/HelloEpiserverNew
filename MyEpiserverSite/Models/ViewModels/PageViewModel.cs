using EPiServer.Core;
using MyEpiserverSite.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; set; }
        public IContent Section { get; set; }

    }
}