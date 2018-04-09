using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using MyEpiserverSite.Helpers.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEpiserverSite.Models.Pages
{
    public class BasePage : PageData
    {
        public virtual string PageTitle
        {
            get
            {
                return this.GetPropertyValue(x => x.PageTitle);
            }
            set
            {
                this.SetPropertyValue(x => x.PageTitle, value);
            }
        }
        public virtual string PageDesc
        {
            get
            {
                return this.GetPropertyValue(x => x.PageDesc);
            }
            set
            {
                this.SetPropertyValue(x => x.PageDesc, value);
            }
        }

        [BackingType(typeof(PropertyNumber))]
        public virtual int PageTitleNumber { get; set; }

        public virtual DateTime PageCreatedDate { get; set; }

        [BackingType(typeof(PropertyAppSettingsMultiple))]
        public virtual string Subsidiaries { get; set; }

        [UIHint(UIHint.Textarea)]
        public virtual string PageIntro { get; set; }

        /*
         *  [Display(Name = "Main Hero Image",
            GroupName = SystemTabNames.Content,
            Order = 20)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference MainHeroImmage { get; set; }
         */

        [UIHint(UIHint.Image)]
        public virtual ContentReference PageImage { get; set; }
    }

    [ContentType(GUID = "bf2a6bbf-5ac1-49fb-aea5-919336501b37")]
    [ImageUrl("~/Content/imgs/page-type-thumbnail.png")]
    public class CommonPageUpdated : BasePage
    {
        public virtual string MainIntro { get; set; }

        public virtual XhtmlString MainBody { get; set; }
        public virtual ContentArea RelatedContentArea { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "PageTitle", Description = "Long Page title")]
        public override string PageTitle
        {
            get
            {
                var title = base.PageTitle;
                if (string.IsNullOrEmpty(title))
                {
                    title = Name;
                }

                return title;
            }
            set
            {
                base.PageTitle = value;
            }
        }
        public override string PageDesc
        {
            get
            {
                var desc = base.PageDesc;
                if (string.IsNullOrEmpty(desc))
                {
                    desc = MainIntro;
                }
                return desc;
            }
            set
            {
                base.PageDesc = value;
            }
        }
    }
}