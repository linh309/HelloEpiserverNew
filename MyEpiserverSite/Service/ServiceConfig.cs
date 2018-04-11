using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEpiserverSite.Service
{
    [InitializableModule]
    public class ServiceConfig : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            //context.Services.AddTransient<IPlainPageService, PlainPageService>();

            context.ConfigurationComplete += (o, e) =>
            {
                //Register custom implementations that should be used in favour of the default implementations
                context.Services.AddTransient<IPlainPageService, PlainPageService>();
            };
        }

        public void Initialize(InitializationEngine context)
        {
            DependencyResolver.SetResolver(new ServiceLocatorDependencyResolver(context.Locate.Advanced));
            //throw new NotImplementedException();
        }

        public void Uninitialize(InitializationEngine context)
        {
            //throw new NotImplementedException();
        }
    }
}