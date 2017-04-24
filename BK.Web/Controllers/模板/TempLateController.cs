using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK.Web.Controllers
{
    public class TempLateController : Controller
    {        
        public ActionResult latestPosts()
        {
            return View();
        }
    }
}