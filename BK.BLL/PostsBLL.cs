using System.Linq;
using BK.Models;
using BK.IBLL;
using BK.IDAL;

namespace BK.BLL
{
    public class PostsBLL : BaseBLL<posts>, IPostsBLL
    {
        private IPostsDAL _dal = DALContainer.Container.Resolve<IPostsDAL>();

        public override void SetDAL()
        {
            DAL = _dal;
        }

        public posts Read(int id)
        {
            var model = DAL.GetModels(d => d.id == id).FirstOrDefault()??new posts();
            model.readcount++;
            DAL.SaveChanges();
            return model;
        }
    }
}
