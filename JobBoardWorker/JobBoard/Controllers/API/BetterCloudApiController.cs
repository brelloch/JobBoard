#region

using Autofac;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

#endregion

namespace JobBoard.Controllers
{

    /// <summary>
    /// This is a base class to be used for all ApiControllers. Right now it is just about passing the
    /// DocumentStore around. In the future this can be used for things suchs as auditing API calls.
    /// </summary>
    public abstract class JobBoardApiController : ApiController
    {
        // Only create once per application start
        public static IDocumentStore DocumentStore { get; set; }
    }
}