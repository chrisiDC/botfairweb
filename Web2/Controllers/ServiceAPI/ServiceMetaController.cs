using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Botfair.Web2.Controllers.ServiceAPI
{
    public class ServiceMetaController : ApiController
    {
       

        public string GetServiceUrl()
        {
            return System.Configuration.ConfigurationManager.AppSettings["controlservice"];
        }

   
    }
}
