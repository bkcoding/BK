using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using BK.BLL;
using BK.Models;

namespace BK.Web.Controllers
{
    public class SidebarController : Controller
    {
        PostsBLL db = new PostsBLL();

        public PartialViewResult Index(int ishome=1)
        {
            ViewBag.ishome = ishome;
            return PartialView(db.GetModels(d => d.mfcOtherName == "note").OrderByDescending(d=>d.readcount).ThenByDescending(d=>d.createTime).Select(d => new SidebarModel()
            {
                ID = d.id,
                title = d.title,
                pic=d.pic,
                writer = d.writer,
                time = d.createTime,
                read = d.readcount,
            }).Take(5));
        }
    }
}
