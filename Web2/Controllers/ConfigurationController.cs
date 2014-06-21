using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Botfair.Web2.Controllers
{
    public class ConfigurationController : Controller
    {
        //
        // GET: /Configuraiton/

        public ActionResult Index()
        {
            Newtonsoft.Json.Linq.JArray x = (Newtonsoft.Json.Linq.JArray)
               Newtonsoft.Json.JsonConvert.DeserializeObject(
                   "[{'Id':10,'Percentage':46,'RiskValue':4,'NewMarketsPeriod':40000}]");

            var a = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiEntities.Configuration>>(
                "[{'Id':10,'Percentage':46,'RiskValue':4,'NewMarketsPeriod':40000}]");
            
            return View();
        }

        public ActionResult InsertConfig()
        {
            return View();
        }


    }
}
