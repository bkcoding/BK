using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BK.Web.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Table()
        {
            return View();
        }

    }
}