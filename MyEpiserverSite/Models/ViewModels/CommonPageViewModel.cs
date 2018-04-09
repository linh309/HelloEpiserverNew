using MyEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.ViewModels
{
    public class CommonPageViewModel
    {
        public CommonPageViewModel() { }
        public CommonPageViewModel(CommonPageUpdated currentPage)
        {
            CommonCurrentPage = currentPage;
        }

        public CommonPageUpdated CommonCurrentPage { get; set; }
        public string AvailableCountries { get; set; }
    }
}