using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using BK.IBLL;
using BK.Models;

namespace BK.Web.Controllers
{
    public class PostsController : Controller
    {
        IPostsBLL db = BLLContainer.Container.Resolve<IPostsBLL>();
        IMfcBLL mf= BLLContainer.Container.Resolve<IMfcBLL>();
        public ActionResult Index(string c="")
        {
            var mfc = mf.GetModels(d => d.otherName == c).FirstOrDefault();
            ViewBag.mfc = mfc;
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
                mfcOtherName=d.mfcOtherName,
                info=d.excerpt
            }));
        }

    }
}