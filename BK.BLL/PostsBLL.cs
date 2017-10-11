﻿using BK.Models;
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
    }
}
