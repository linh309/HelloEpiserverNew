using EPiServer.Core;
using EPiServer.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Helpers
{
    public static class FormattingExtensions
    {
        public static HtmlString ToHtmlLineBreaks(this string value)
        {
            var parsed = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                parsed = HttpUtility.HtmlEncode(value);
                parsed = parsed.Replace("\n", "<br />");
            }

            return new HtmlString(parsed);
        }

        public static string GetReadMoreText()
        {
            var text = LocalizationService.Current.GetString("/views/common/readmore");
            return text;
        }

        public static PageReference GetPageReference(int pageId)
        {
            var pageRef = new PageReference(pageId);
            return pageRef;
        }
    }
}