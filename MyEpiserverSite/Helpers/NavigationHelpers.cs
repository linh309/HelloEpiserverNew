using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using MyEpiserverSite.Models.Pages;

namespace MyEpiserverSite.Helpers
{
    public static class NavigationHelpers
    {
        public static void RenderMainNavigation(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null)
        {
            var writer = html.ViewContext.Writer;
            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();
            rootLink = rootLink ?? ContentReference.StartPage;

            //Top level elements
            writer.WriteLine("<nav class=\"navbar navbar-inverse\">");
            writer.WriteLine("<ul class=\"nav navbar-nav\">");

            if (includeRoot)
            {
                //Link to start page
                writer.WriteLine(MakeActiveLink(contentLink, rootLink));
                writer.WriteLine(html.PageLink(rootLink).ToHtmlString());
                writer.WriteLine("</li>");
            }

            //get child elements
            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();
            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);

            var filterPage = FilterForVisitor.Filter(topLevelPages).OfType<PageData>().Where(x => x.VisibleInMenu);


            foreach (var topPage in topLevelPages)
            {
                //create li for page
                //writer.WriteLine("<li>");
                writer.WriteLine(MakeActiveLink(contentLink, topPage.ContentLink));
                writer.WriteLine(html.PageLink(topPage));
                writer.WriteLine("</li>");
            }

            //close tags
            writer.WriteLine("</ul>");
            writer.WriteLine("</nav>");
        }

        private static string MakeActiveLink(ContentReference contentLink, ContentReference selectedLink)
        {
            var activeLink = "<li>";
            if (contentLink.CompareToIgnoreWorkID(selectedLink))
            {
                activeLink = "<li class=\"active\">";
            }

            return activeLink;
        }

        public static void RenderSubNavigation(this HtmlHelper html,
            ContentReference contentLink = null,
            IContentLoader contentLoader = null)
        {
            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();
            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            var path = contentLoader.GetAncestors(contentLink)
                        .Reverse()
                        .SkipWhile(x => ContentReference.IsNullOrEmpty(x.ParentLink)
                                    || !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                        .OfType<PageData>()
                        .Select(x => x.PageLink)
                        .ToList();



            var currentPage = contentLoader.Get<IContent>(contentLink) as PageData;
            if (currentPage != null)
            {
                path.Add(currentPage.PageLink);
            }

            var root = path.FirstOrDefault();
            if (root == null)
            {
                return;
            }

            RenderSubNavigationLevel(html, root, path, contentLoader);
        }

        private static void RenderSubNavigationLevel(HtmlHelper helper,
            ContentReference levelRootLink,
            IEnumerable<ContentReference> path,
            IContentLoader contentLoader)
        {
            var children = contentLoader.GetChildren<PageData>(levelRootLink);
            if (!children.Any())
            {
                //There's nothing to render on this level so we abort
                //in order not to write an empty ul element.
                return;
            }

            var writer = helper.ViewContext.Writer;
            writer.WriteLine("<ul class=\"nav\">");

            var indexedChildren = children
                                    .Select((page, index) => new { index, page })
                                    .ToList();
            foreach (var levelItem in indexedChildren)
            {
                var page = levelItem.page;
                var partOfCurrentBranch = path.Any(x =>
                x.CompareToIgnoreWorkID(levelItem.page.ContentLink));

                if (partOfCurrentBranch)
                {
                    writer.WriteLine("<li class=\"active\">");
                }
                else
                {
                    writer.WriteLine("<li>");
                }

                writer.WriteLine(helper.PageLink(page).ToHtmlString());

                if (partOfCurrentBranch)
                {
                    //The page is part of the current pages branch,
                    //so we render a level below it
                    RenderSubNavigationLevel(
                    helper,
                    page.ContentLink,
                    path,
                    contentLoader);
                }

                writer.WriteLine("</li>");
            }

            writer.WriteLine("</ul>");
        }
    }
}