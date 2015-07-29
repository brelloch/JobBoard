using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using JobBoard.Controllers;

namespace JobBoard
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run();
            InitializeDocumentStore();
        }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return; // prevent misuse

            var convention = new DocumentConvention
            {
                FindTypeTagName = t =>
                {
                    return DocumentConvention.DefaultTypeTagName(t);
                },
                IdentityPartsSeparator = "-"
            };

            var parser = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionStringName("RavenDB");
            parser.Parse();

            DocumentStore store = new DocumentStore
            {
                ApiKey = parser.ConnectionStringOptions.ApiKey,
                Url = parser.ConnectionStringOptions.Url,
                DefaultDatabase = parser.ConnectionStringOptions.DefaultDatabase,
                Conventions = convention
            };

            DocumentStore = store.Initialize();

            JobBoardApiController.DocumentStore = DocumentStore;
        }
    }
}
