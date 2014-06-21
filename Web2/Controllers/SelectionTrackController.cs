using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Botfair.Web2.Controllers
{
    public class SelectionTrackController : Controller
    {
        //
        // GET: /SelectionTrack/

        public ActionResult Default(int marketId)
        {
            return View();
        }

    }
}
