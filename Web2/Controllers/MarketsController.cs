using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Botfair.Web2.Models.Markets;

namespace Botfair.Web2.Controllers
{
    public class MarketsController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            return View();
        }

        public PartialViewResult Selections(SelectionsModel model)
        {
            
            return PartialView(model);
        }

    }
}
