using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using BK.BLL;
using BK.Models;

namespace BK.Web.Controllers
{
    public class PostsController : Controller
    {
        PostsBLL db = new PostsBLL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id=0)
        {
            var model = db.Read(id);
            return View(model);
        }

        public PartialViewResult GetPosts(string c,int page, int size)
        {
            return PartialView(db.GetModelsByPage(size,page,false,d=>d.createTime,d=>d.mfcOtherName==c).Select(d=>new ViewPostsModelNoContent() {
                ID = d.id,
                title = d.title,
                writer = d.writer,
                pic=d.pic,
                time = d.createTime,
                read = d.readcount,
                mfcName=d.mfcName,
                info=d.excerpt
            }));
        }

    }
}