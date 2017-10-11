using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BK.BLL;

namespace BK.Web.Controllers
{
    public class PostsController : Controller
    {
        PostsBLL db = new PostsBLL();
        
        public ActionResult Index(string c)
        {            
            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }

        public PartialViewResult View(string c, int id)
        {
            return PartialView();
        }

    }
}