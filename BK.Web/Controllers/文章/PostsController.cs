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
        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult lastest(int count, int index)
        {
            try
            {
                PostsFuns db = new PostsFuns();
                int c = db.ViewListALL().Count();
                int p = c / count;
                if (c % count > 0)
                {
                    p++;
                }
                return Json(new {list= db.ViewListALL().Select(d=>new { img = d.posts_img, title = d.posts_tile, tag = d.category.category_name, @abstract = d.posts_abstract, url = "/Posts/Details/"+d.posts_id, createTime = d.posts_createTime, writer = d.posts_writer, commentCount = d.posts_commentCount, readCount = d.posts_readCount }).Skip((index - 1) * count).Take(count), pages=p }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}