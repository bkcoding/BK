using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BK.Web.Controllers
{
    public class SidebarController : Controller
    {
        public PartialViewResult Index(string type)
        {
            return PartialView();
        }
    }
}
