using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Models
{
    public partial class posts
    {
        partial void OnCreated()
        {
            posts_isdel = false;
            posts_tile = "";
            posts_img = "";
            posts_writer = "";
            posts_createTime = DateTime.Now;
            posts_readCount = 0;
            posts_commentCount = 0;
            posts_abstract = "";
            posts_content = "";
        }
    }
}
